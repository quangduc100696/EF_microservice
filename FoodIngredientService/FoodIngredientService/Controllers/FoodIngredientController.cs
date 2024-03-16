using DataModel;
using FoodIngredientService.Command;
using FoodIngredientService.DTO;
using Infrastructure.Core.Command;
using Infrastructure.Core.Query;
using Microsoft.AspNetCore.Mvc;
using static FoodIngredientService.Query.GetFoodIngredientQuery;

namespace FoodIngredientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodIngredientController : ControllerBase
    {

        private DbContextData _dbContext;
        private IQueryBus _queryBus;

        public FoodIngredientController(DbContextData dbContext, IQueryBus queryBus)
        {
            _dbContext = dbContext;
            _queryBus = queryBus;
        }

        [HttpGet]
        public async Task<ActionResult<FoodIngredientDTO>> GetFood(int id, CancellationToken cancellationToken)
        {
            var query = new QueryData
            {
                Id = id,
            };

            var result = await _queryBus.Send(query, cancellationToken);

            return Ok(result);
        }

        //[HttpPost]
        //public async Task<ActionResult<CreateFoodIngredientCommand.Result>> CreateFood([FromBody] CreateFoodIngredientCommand.FoodIngredientCreate food, CancellationToken cancellationToken)
        //{
        //    var result = await _commandBus.Send(food, cancellationToken);

        //    return Ok(result);
        //}
    }
}
