using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Model
{
    [Table("food")]
    public class Food
    {
        [Key]
        [Required]
        public int Id { get; set; }
        // [ForeignKey("FoodId")]
        // public List<FoodIngredient> FoodIngredients { get; set;}

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Code { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
