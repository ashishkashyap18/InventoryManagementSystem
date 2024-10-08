using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Production
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public double Qty { get; set; }

        public Employee? Employee { get; set; }
        public Product? Product { get; set; }
        public Unit? Unit { get; set; }

    }
}
