using Microsoft.AspNetCore.Mvc;
using MTApp.API.Models.DTOs;
using MTApp.API.Modules.LanguageModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LanguageDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new LanguageListQuery()));
        }
    }
}
