using DaihoWebAPI.Data;
using DaihoWebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using DaihoWebAPI.Repositories;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly OraDbContext _context;
        private readonly string _connectionString;
        private readonly AuthRepository authRepository;

        //private readonly WmUser _user;
        public AuthController(OraDbContext context, IConfiguration configuration, AuthRepository authRepository)
        {
            _context = context;
            this.authRepository = authRepository;
           
        }
            [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users users)
        {

            var result = await authRepository.getAuth(users.userName, users.Password);
            if (result != null)
            {

                return Ok(result);
            }
            
            return BadRequest();

        }

    }
}
