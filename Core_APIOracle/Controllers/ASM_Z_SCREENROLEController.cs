using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;
using DaihoWebAPI.Repositories;
using DaihoWebAPI.Utilities;
using DaihoWebAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Components.Server;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ASM_Z_SCREENROLEController : ControllerBase
    {
        private readonly OraDbContext dbContext;
        private readonly IASM_Z_SCREEN_ROLE _aSM_Z_SCREEN_ROLE;

        public ASM_Z_SCREENROLEController(OraDbContext dbContext, IASM_Z_SCREEN_ROLE _aSM_Z_SCREEN_ROLE)
        {
            this.dbContext = dbContext;
            this._aSM_Z_SCREEN_ROLE = _aSM_Z_SCREEN_ROLE;
        }

        [HttpPost ]
        public async Task<IActionResult> CreateAsync([FromBody] ASM_Z_SCREEN_ROLE aSM_Z_SCREEN_ROLE)
        {
            
                var resp = await _aSM_Z_SCREEN_ROLE.CreateAsync(aSM_Z_SCREEN_ROLE);
                return StatusCode(resp.Code, resp);
            
        }
           

        [HttpDelete("deleteUserByID/{id}")]
       public async Task<IActionResult> deleteAsync(string id)
        {
            var resp = await _aSM_Z_SCREEN_ROLE.deleteAsync(id);
            return Ok(resp);
        }
        [HttpDelete("deleteUserBody")]
        public async Task<IActionResult> deleteAsyncFromBody([FromBody] RoleIdDto roleID)
        {
            var resp = await _aSM_Z_SCREEN_ROLE.deleteAsyncDto(roleID);
            return Ok(resp);
        }

        [HttpGet("getUserScreen")]
        public async Task<IActionResult> GetAllAsync()
        {
            var screenRole = await _aSM_Z_SCREEN_ROLE.GetAllAsync();
            return Ok(screenRole);
        }

        [HttpGet("getUserScreenList")]
        public async Task<IActionResult> GetAllListAsync()
        {
            var screenRole = await _aSM_Z_SCREEN_ROLE.GetAllListAsync();
            return Ok(screenRole);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var screenRole = await _aSM_Z_SCREEN_ROLE.GetById(id);
            return Ok(screenRole);
        }
    }
}
