using System.ComponentModel.DataAnnotations;

namespace SDA_WEB_API.DataLayer.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Adress { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
