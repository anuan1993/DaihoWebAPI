using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.Repositories
{
    public class ASM_Z_SCREENRepository : IASM_Z_SCREENS
    {
        private readonly OraDbContext dbContext;

        public ASM_Z_SCREENRepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ASM_Z_SCREEN> CreateAsync(ASM_Z_SCREEN aSM_Z_SCREEN)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.ASM_Z_SCREENs.AddAsync(aSM_Z_SCREEN);
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Utils.Errors.WrapDuplicateError(e, "duplicate role");
                }
            }
            return aSM_Z_SCREEN;
        }

        public async Task<IEnumerable<ASM_Z_SCREEN>> GetAllAsync()
        {
            return await dbContext.ASM_Z_SCREENs.ToListAsync();
        }
    }
}
