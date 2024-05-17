using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DaihoWebAPI.Repositories;
using DaihoWebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using DaihoWebAPI.Models;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ASM_Z_ROLEController : ControllerBase
    {
        private readonly OraDbContext dbContext;
        private readonly IASM_Z_ROLE aSM_Z_ROLE;

        public ASM_Z_ROLEController(OraDbContext dbContext, IASM_Z_ROLE aSM_Z_ROLE)
        {
            this.dbContext = dbContext;
            this.aSM_Z_ROLE = aSM_Z_ROLE;
        }
        [HttpGet]
        
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var role = await aSM_Z_ROLE.getAllSync();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ASM_Z_ROLES roles)
        {
            var resp = await aSM_Z_ROLE.CreateAsync(roles);
            return Ok( resp);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var resp = await aSM_Z_ROLE.GetById(id);
            return Ok(resp);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(string id,ASM_Z_ROLES role)
        {
            var resp=await aSM_Z_ROLE.UpdateAsync(id,role); 
            return Ok(resp);    
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteAsync(string id)
        {
            var resp = await aSM_Z_ROLE.deleteAsync(id);
            return Ok(resp);
        }

    }
}
