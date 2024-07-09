using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private static List<Song> Songs()
        {
            var list = new List<Song>
            {
                new Song
                {
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    Singer = "Prince",
                    Title = "Kiss"
                },
                new Song
                {
                    Id = 2,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    Singer = "Spice girls",
                    Title = "Wannabe"
                },
                new Song
                {
                    Id = 3,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                    Singer = "Travis",
                    Title = "Side"
                }
                ,
                new Song
                {
                    Id = 4,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                    Singer = "Travis",
                    Title = "Sing"
                },
                new Song
                {
                    Id = 5,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                    Singer = "Spice Girls",
                    Title = "Spice up your life"
                }
            };
            return list;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var item = Songs().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return new OkObjectResult(item);
            }
            else return new NotFoundResult();
        }


        [HttpGet()]
        public ActionResult GetByfilter(
            [FromQuery] DateOnly? date, 
            [FromQuery] string? title,
            [FromQuery] string? singer)
        {
            var result = Songs();
            if (date != null)
            {
                result = result.Where(x => x.Date == date).ToList();
            }
            if (title != null)
            {
                result = result.Where(x => string.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (singer != null) {
                result = result.Where(x => string.Equals(x.Singer, singer, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return new OkObjectResult(result);
        }
    }
}
