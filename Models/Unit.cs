using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Unit
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string? UnitName { get; set; }
        [Required]
        public string? UOM { get; set; }
    }
}
