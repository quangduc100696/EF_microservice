using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Event;

namespace Event.Model
{
    public class FoodIngredientEvent : IEvent
    {
        public int FoodIngredientId { get; set; }

        public int Id { get; set; }

        public string FoodIngredientName { get; set; }

        public string FoodIngredientCode { get; set; }

        public string FoodIngredientDescription { get; set; }
    }
}
