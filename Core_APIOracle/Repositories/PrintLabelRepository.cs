using Core_APIOracle.Models;
using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.Repositories

{
    public class PrintLabelRepository : IPrintLabelRepository
    {
        private readonly OraDbContext dbContext;

        public PrintLabelRepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PrintLabel>> GetAllAsync()
        {
           return await dbContext.ST_ORDER_ALLs.ToListAsync();  
        }

        //public Task<IActionResult> DeleteAsync(string id)
        //{
        //    return NoContent;
        //}


    }
}
