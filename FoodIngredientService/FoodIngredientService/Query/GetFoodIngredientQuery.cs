using DataModel;
using DataModel.Model;
using Event.Model;
using FoodIngredientService.DTO;
using Infrastructure.Core;
using Infrastructure.Core.Event;
using Infrastructure.Core.Query;
using MediatR;

namespace FoodIngredientService.Query
{
    public class GetFoodIngredientQuery
    {
        public class QueryData : IQuery<FoodIngredientDTO>
        {
            public int Id { get; set; }
        }

        public class Handler : IQueryHandler<QueryData, FoodIngredientDTO>
        {
            private DbContextData _db;

            public Handler(DbContextData db)
            {
                _db = db;
            }

            async Task<FoodIngredientDTO> IRequestHandler<QueryData, FoodIngredientDTO>.Handle(QueryData request, CancellationToken cancellationToken)
            {
                var foodIngredient = _db.foodIngredients.SingleOrDefault(x => x.FoodIngredientId == request.Id);

                var result = new FoodIngredientDTO();

                if (foodIngredient != null)
                {
                    result = Mapping.Map<FoodIngredient, FoodIngredientDTO>(foodIngredient);
                }

                return result;
            }
        }

        public class EventHandler : IEventHandler<FoodIngredientEvent>
        {
            private DbContextData _dbContextData;
            private IEventBus _eventBus;

            public EventHandler(DbContextData dbContextData, IEventBus eventBus)
            {
                _dbContextData = dbContextData;
                _eventBus = eventBus;
            }

            public async Task Handle(FoodIngredientEvent notification, CancellationToken cancellationToken)
            {
                var data = _dbContextData.foodIngredients.FirstOrDefault(x => x.FoodId == notification.Id);

                var @event = Mapping.Map<FoodIngredient, FoodIngredientEvent>(data);

                await _eventBus.Commit(@event);
            }
        }
    }
}
