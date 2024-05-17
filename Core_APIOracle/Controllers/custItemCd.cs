using DaihoWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_APIOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class custItemCd : ControllerBase
    {
        private readonly OraDbContext _context;

        public custItemCd(OraDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await (from b in _context.custItemCds
                             //   where b.CST_CD == custCD
                                orderby b.ITM_CD
                                select b).ToListAsync();

            return Ok(result);
        }

    }
}
