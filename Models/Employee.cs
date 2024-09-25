using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        public bool OnSite { get; set; }
        public bool IsWorking { get; set; }
    }
}
