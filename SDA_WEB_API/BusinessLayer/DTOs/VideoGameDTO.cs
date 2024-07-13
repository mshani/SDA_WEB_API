using System.ComponentModel.DataAnnotations;

namespace SDA_WEB_API.BusinessLayer.DTOs
{
    public class VideoGameDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public string? Studio { get; set; }
    }
}
