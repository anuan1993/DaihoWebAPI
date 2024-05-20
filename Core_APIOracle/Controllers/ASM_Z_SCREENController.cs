using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASM_Z_SCREENController : ControllerBase
    {
        private readonly OraDbContext dbContext;
        private readonly IASM_Z_SCREENS aSM_Z_SCREENS;

        public ASM_Z_SCREENController(OraDbContext dbContext, IASM_Z_SCREENS aSM_Z_SCREENS)
        {
            this.dbContext = dbContext;
            this.aSM_Z_SCREENS = aSM_Z_SCREENS;
        }

        [HttpGet]
        public async Task<IActionResult> GetResultAsync()
        {
            var screen = await aSM_Z_SCREENS.GetAllAsync();
            return Ok(screen);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ASM_Z_SCREEN screen)
        {
            
            var resp = await aSM_Z_SCREENS.CreateAsync(screen);
            return StatusCode(resp.Code, resp);
        }
    }
}
