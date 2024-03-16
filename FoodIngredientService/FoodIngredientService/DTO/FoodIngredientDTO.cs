using Infrastructure.Core.Event;

namespace FoodIngredientService.DTO
{
    public class FoodIngredientDTO : IEvent
    {
        public int FoodIngredientId { get; set; }

        public int FoodId { get; set; }

        public string FoodIngredientName { get; set; }

        public string FoodIngredientCode { get; set; }

        public string FoodIngredientDescription { get; set; }
    }
}
