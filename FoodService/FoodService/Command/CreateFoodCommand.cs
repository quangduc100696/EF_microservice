using DataModel;
using DataModel.Model;
using FoodService.DTOs;
using Infrastructure.Core;
using Infrastructure.Core.Command;
using Infrastructure.Core.Event;
using MediatR;

namespace FoodService.Command
{
    public class CreateFoodCommand
    {
        public class FoodCreate :  ICommand<Result>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Code { get; set; }

            public string Description { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<FoodCreate, Result>
        {
            private DbContextData _dbContextData;
            private IEventBus _eventBus;

            public Handler(DbContextData dbContextData, IEventBus eventBus)
            {
                _dbContextData = dbContextData;
                _eventBus = eventBus;
            }

            public async Task<Result> Handle(FoodCreate request, CancellationToken cancellationToken)
            {
                var food = new Food
                {
                    Id = request.Id,
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description
                };

                await _dbContextData.AddAsync(food);

                var @event = Mapping.Map<Food, FoodCreateEvent>(food);

                @event.Id = food.Id;

                await _dbContextData.SaveChangesAndCommit(@event);

                var result = new Result
                {
                    Id = Guid.NewGuid(),
                };

                return result;
            }
        }
    } 
}
