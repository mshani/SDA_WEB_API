using System.ComponentModel.DataAnnotations;

namespace SDA_WEB_API.DataLayer.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string? Name { get; set; }
        public int Size { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        public int PublisherId {  get; set; }
        public Publisher Publisher { get; set; }
    }
}
