using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;
using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly OraDbContext dbContext;
        private readonly IUserRoleRepository _userRole;

        public UserRolesController(OraDbContext dbContext, IUserRoleRepository _userRole)
        {
            this.dbContext = dbContext;
            this._userRole = _userRole;
        }

        [HttpGet("getUserRole")]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var UserRole = await _userRole.GetAllAsync();
            return Ok(UserRole);
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> GetUserAsync()
        {
            var UserRole = await _userRole.GetUserAsync();
            return Ok(UserRole);
        }

        [HttpPost]
        public async Task<IActionResult>CreateAsync([FromBody] userRole userRole)
        {
            var resp = await _userRole.CreateAsync(userRole);
            return Ok(resp);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateAsync(string id, RoleIdDto userRole)
        {
            var resp = await _userRole.UpdateAsync(id, userRole);
            return Ok(resp);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteAsync([FromBody] UserRolesDTO userRoles)
        {
            var resp = await _userRole.deleteAsync(userRoles);
            return Ok(resp);
        }


    }
}
