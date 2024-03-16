using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    [Table("FoodIngredient")]
    public class FoodIngredient
    {
        [Key]
        [Required]
        public int FoodIngredientId { get; set; }

        public int FoodId { get; set; }

        [Required]
        [Column(TypeName = ("varchar(255)"))]
        public string FoodIngredientName { get; set; }

        [Required]
        [Column(TypeName = ("varchar(100)"))]
        public string FoodIngredientCode { get; set; }

        [Column(TypeName = ("text"))]
        public string FoodIngredientDescription { get; set; }
    }
}
