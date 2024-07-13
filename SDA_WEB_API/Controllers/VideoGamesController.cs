using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.BusinessLayer.DTOs;
using SDA_WEB_API.BusinessLayer.Infrastucture;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameService videoGameService;
        public VideoGamesController(IVideoGameService videoGameService)
        {
            this.videoGameService = videoGameService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VideoGameDTO payload)
        {
            var result = await videoGameService.Create(payload);
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await videoGameService.GetById(id);
            if (result == null) { return new NoContentResult(); }
            else
            {
                return new OkObjectResult(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] VideoGame payload)
        {
            var result = await videoGameService.Update(id, payload);
            if (result == null) { 
                return new BadRequestObjectResult("Update error");
            }
            else
            {
                return new OkObjectResult(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await videoGameService.Delete(id);
            if (result == true)
            {
                return new OkResult();
            }
            else
            {
                return new UnprocessableEntityObjectResult("Not found");
            }
        }
    }
}

