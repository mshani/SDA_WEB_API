using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(VideoGame videoGame)
        {
            return new OkResult();
        }
    }
}


//public async Task<ActionResult<>> PostProduct(Product product)
//{
//    _context.Product.Add(product);
//    await _context.SaveChangesAsync();

//    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
//}