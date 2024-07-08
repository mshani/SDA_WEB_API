namespace SDA_WEB_API.DataLayer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Singer { get; set; }
        public string? Title { get; set; }       
    }
}
