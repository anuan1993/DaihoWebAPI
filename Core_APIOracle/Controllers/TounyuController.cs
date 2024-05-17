using DaihoWebAPI.Data;
using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TounyuController : ControllerBase
    {
        private readonly OraDbContext _context;
        public TounyuController(OraDbContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        [Route("{INST_NO}")]
        public  async Task<IActionResult> Get(string INST_NO)
        {

            /*var result = await (from b in _context.Tounyus
                                where b.INST_NO == INST_NO
                                //orderby b.CItmCd
                                select b).ToListAsync();*/
            //var result = await TounyuRepository.GetTounyuAsync(INST_NO);
            var result =  _context.Tounyus.FirstOrDefault(x => x.INST_NO == INST_NO);
            return Ok(result);


        }


    }
}
