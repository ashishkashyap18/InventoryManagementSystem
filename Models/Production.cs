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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public double Qty { get; set; }

        public Employee? Employee { get; set; }
        public Product? Product { get; set; }      

    }
}
