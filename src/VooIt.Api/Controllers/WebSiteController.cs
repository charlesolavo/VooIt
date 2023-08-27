using Microsoft.AspNetCore.Mvc;
using VooIt.Domain.Contracts.Services;
using VooIt.Domain.Models;

namespace VooIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteController : ControllerBase
    {
        private readonly IWebSiteService _webSiteService;

        public WebSiteController(IWebSiteService webSiteService)
        {
            _webSiteService = webSiteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _webSiteService.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post(string id, [FromBody] RequestModel model)
        {
            await _webSiteService.Create(id, model);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] RequestModel model)
        {
            await _webSiteService.Update(id, model);

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _webSiteService.Remove(id);

            return Ok();
        }
    }
}
