using DataModel;
using DataModel.Model;
using FoodService.Command;
using FoodService.DTOs;
using Infrastructure.Core.Command;
using Infrastructure.Core.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using static FoodService.Query.GetFoodQuery;

namespace FoodService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private ICommandBus _commandBus;
        private IQueryBus _queryBus;

        public FoodController(ICommandBus  commandBus, IQueryBus queryBus) {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet]
        public async Task<ActionResult<FoodCreateEvent>> GetFoods(int id)
        {
            var query = new QueryFood
            {
                Id = id
            };

            var result = new FoodCreateEvent();

            try
            {
                result = await _queryBus.Send(query);

            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateFoodCommand.Result>> CreateFood([FromBody] CreateFoodCommand.FoodCreate food, CancellationToken cancellationToken)
        {
            var result = await _commandBus.Send(food, cancellationToken);

            return Ok(result);
        }
    }
}
