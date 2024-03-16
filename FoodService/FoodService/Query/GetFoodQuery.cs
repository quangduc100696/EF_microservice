using DataModel;
using DataModel.Model;
using Event.Model;
using FoodService.DTOs;
using Infrastructure.Core;
using Infrastructure.Core.Event;
using Infrastructure.Core.Query;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Query
{
    public class GetFoodQuery
    {
        public class QueryFood : IQuery<FoodCreateEvent>
        {
            public int Id { get; set; }
        }

        public class Result
        {
            public FoodCreateEvent food { get; set; }

            public FoodIngredientEvent foodIngredient { get; set; }
        }

        public class Handler : IQueryHandler<QueryFood, FoodCreateEvent>
        {
            private DbContextData _db;
            private IEventBus _eventBus;

            public Handler(DbContextData db, IEventBus eventBus)
            {
                _db = db;
                _eventBus = eventBus;
            }

            public async Task<FoodCreateEvent> Handle(QueryFood request, CancellationToken cancellationToken)
            {
                var result = new FoodCreateEvent();

                var data = await _db.Foods.FirstOrDefaultAsync(x => x.Id == request.Id);

                result = Mapping.Map<Food, FoodCreateEvent>(data);

                await _eventBus.Commit(result);


                return result;
            }
        }

        //public class HandlerEvent : IEventHandler<FoodIngredientEvent>
        //{
        //    public Task Handle(FoodIngredientEvent notification, CancellationToken cancellationToken)
        //    {
        //        var data = new FoodIngredientEvent();

        //        return Task.CompletedTask;
        //    }
        //}
    }
}
