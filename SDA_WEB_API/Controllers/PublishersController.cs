﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.BusinessLayer.Infrastucture;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService publisherService;
        public PublishersController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Publisher payload)
        {
            var result = await publisherService.Create(payload);
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await publisherService.GetById(id);
            if (result == null) { return new NoContentResult(); }
            else
            {
                return new OkObjectResult(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Publisher payload)
        {
            var result = await publisherService.Update(id, payload);
            if (result == null) { return new UnprocessableEntityObjectResult("Update error"); }
            else
            {
                return new OkObjectResult(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var result =  await publisherService.Delete(id);
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
