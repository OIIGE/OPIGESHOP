using OPIGESHOP.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPIGESHOP.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Price must be between 1 and 10,000,000.")]
        [Column(TypeName = "decimal(18, 2)")]  // Ensures proper precision and scale in the database
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Category Category { get; set; }

        [StringLength(300, ErrorMessage = "Description can't be longer than 300 characters.")]
        public string Description { get; set; }

        public string Image { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Unit must be a non-negative value.")]
        public int Unit { get; set; }
    }
}
