using Microsoft.AspNetCore.Mvc;
using MTApp.API.Models.DTOs;
using MTApp.API.Modules.NewsModule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseApiController
    {
        [HttpGet("{lang}")]
        public async Task<ActionResult<List<NewsRequest>>> GetAll(string lang)
        {
            return Ok(await Mediator.Send(new NewsListQuery { Language = lang }));
        }

        [HttpGet("{id}/{lang}")]
        public async Task<ActionResult<NewsRequest>> GetAll(int id, string lang)
        {
            return Ok(await Mediator.Send(new NewsIdQuery { Language = lang, Id = id }));
        }
    }
}
