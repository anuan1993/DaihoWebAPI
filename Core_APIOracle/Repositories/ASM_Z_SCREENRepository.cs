using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DaihoWebAPI.Repositories
{
    public class ASM_Z_SCREENRepository : IASM_Z_SCREENS
    {
        private readonly OraDbContext dbContext;

        public ASM_Z_SCREENRepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Responses> CreateAsync(ASM_Z_SCREEN aSM_Z_SCREEN)
        {
            ASM_Z_SCREEN? sCREEN = null;
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
                    if (Utils.Errors.IsDuplicateRecordException(e))
                    {
                        return Utilities.Utils.NewErrorResponse(null, e.Message,Constants.Status.Conflict, (int)HttpStatusCode.Conflict) ;
                    }
                    return Utils.NewErrorResponse(null, e.Message, Constants.Status.InternalServerErr, (int)System.Net.HttpStatusCode.InternalServerError);
                    throw;
                }
            }
            return Utils.NewSuccessResponse(aSM_Z_SCREEN, null);
        }

        public async Task<IEnumerable<ASM_Z_SCREEN>> GetAllAsync()
        {
            return await dbContext.ASM_Z_SCREENs.ToListAsync();
        }
    }
}
