using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public int UnitId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Rate { get; set; }
        public Unit? Unit { get; set; }
    }
}
