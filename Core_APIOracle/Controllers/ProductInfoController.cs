using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_APIOracle.Models;
using Microsoft.EntityFrameworkCore;
using DaihoWebAPI.Data;

namespace Core_APIOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly OraDbContext _context;

        public ProductInfoController(OraDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Route("{PROD_ITM_GRP_CD}")]
        public async Task<IActionResult> Get(string PROD_ITM_GRP_CD)
        {
            var result = await (from b in _context.Products 
                                where b.CO_CD== PROD_ITM_GRP_CD
                                //orderby b.ITM_CD
                                select b).ToListAsync();

            return Ok(result);
        }

        

        [HttpPost]
        public async Task<IActionResult> Post(ProductsInfo productsInfo)
        {
            var result = await _context.Products.AddAsync(productsInfo);
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }

       
    }


}
