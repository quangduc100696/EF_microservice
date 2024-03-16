using DataModel;
using DataModel.Model;
using Event.Model;
using FoodIngredientService.DTO;
using Infrastructure.Core;
using Infrastructure.Core.Command;
using Infrastructure.Core.Event;
using MediatR;
using System;

namespace FoodIngredientService.Command
{
    public class CreateFoodIngredientCommand
    {
        public class FoodIngredientCreate : ICommand<Result>
        {
            public int FoodIngredientId { get; set; }

            public int FoodId { get; set; }

            public string FoodIngredientName { get; set; }

            public string FoodIngredientCode { get; set; }

            public string FoodIngredientDescription { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<FoodIngredientCreate, Result>
        {
            private DbContextData _dbContextData;
            private IEventBus _eventBus;

            public Handler(DbContextData dbContextData, IEventBus eventBus)
            {
                _dbContextData = dbContextData;
                _eventBus = eventBus;
            }

            public async Task<Result> Handle(FoodIngredientCreate request, CancellationToken cancellationToken)
            {
                //var food = new Food
                //{
                //    Id = request.Id,
                //    Name = request.Name,
                //    Code = request.Code,
                //    Description = request.Description
                //};

                //await _dbContextData.AddAsync(food);

                //var @event = Mapping.Map<Food, FoodCreateEvent>(food);

                //@event.Id = food.Id;

                //await _dbContextData.SaveChangesAndCommit(@event);

                var result = new Result
                {
                    Id = Guid.NewGuid(),
                };

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
                var data = Mapping.Map<FoodIngredientEvent, FoodIngredient>(notification);

                data.FoodId = notification.Id;
                data.FoodIngredientName = "Test";
                data.FoodIngredientCode = "TS";
                data.FoodIngredientDescription = "TS";

                _dbContextData.Add(data);

               await _dbContextData.SaveChangesAsync();
            }
        }
    }
}
