using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using DaihoWebAPI.Repositories;

namespace DaihoWebAPI.Repositories
{
    public class TounyuRepository : ITounyuRepository
    {
        private readonly OraDbContext dbContext;

        public TounyuRepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /* public async Task<Tounyu> GetTounyuAsync(string INST_NO)
         {
             //var result = await(from b in dbContext.Tounyus
             //                  where b.INST_NO == INST_NO
             //                 //orderby b.CItmCd
             //                select b).FirstOrDefaultAsync();
             //return result;

             return await dbContext.Tounyus.FirstOrDefaultAsync(x => x.INST_NO == INST_NO);
         }}*/

    }
}
