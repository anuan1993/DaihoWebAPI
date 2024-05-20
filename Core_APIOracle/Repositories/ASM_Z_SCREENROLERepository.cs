using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;
using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace DaihoWebAPI.Repositories
{
    public class ASM_Z_SCREENROLERepository : IASM_Z_SCREEN_ROLE
    {
        private readonly OraDbContext dbContext;

        public ASM_Z_SCREENROLERepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Responses> CreateAsync(ASM_Z_SCREEN_ROLE ScreenRole)
        {

            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.aSM_Z_SCREEN_ROLEs.AddAsync(ScreenRole);
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    if (Utils.Errors.IsDuplicateRecordException(e))
                    {
                        return Utilities.Utils.NewErrorResponse(null, e.Message, Constants.Status.Conflict, (int)HttpStatusCode.Conflict);
                    }
                    return Utils.NewErrorResponse(null, e.Message, Constants.Status.InternalServerErr, (int)System.Net.HttpStatusCode.InternalServerError);
                    throw;
                }
            }
            return Utils.NewSuccessResponse(ScreenRole, null); ;
        }

        public async Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsync(string id)
        {
            var roleScreen = await dbContext.aSM_Z_SCREEN_ROLEs
             .Where(item => item.ROLEID ==id) // Assuming Id is the primary key property
             .ToListAsync();

            if (roleScreen == null || !roleScreen.Any())
            {
                return null; // If no role(s) found, return null
            }
            //foreach (var roleScreenDel in roleScreen)
            //{
            //    dbContext.aSM_Z_SCREEN_ROLEs.Remove(roleScreenDel);
            //}
            dbContext.aSM_Z_SCREEN_ROLEs.RemoveRange(roleScreen);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return roleScreen;

        }

        public async Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsyncDto(RoleIdDto idDto)
        {
            var roleId = await dbContext.aSM_Z_SCREEN_ROLEs
           .Where(item => item.ROLEID == idDto.roleID) // Assuming Id is the primary key property
           .ToListAsync();

            if (roleId == null || !roleId.Any())
            {
                return null; // If no role(s) found, return null
            }
            //foreach (var roleDel in roleId)
            //{
            //    dbContext.aSM_Z_SCREEN_ROLEs.Remove(roleDel);
            //}

            dbContext.aSM_Z_SCREEN_ROLEs.RemoveRange(roleId);
            try
            {
                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the concurrency exception details if you have a logging framework
                // For example: _logger.LogError(ex, "Concurrency exception occurred while deleting roles.");

                // Optionally, you can retry the operation or handle it as per your business logic
                throw new InvalidOperationException("Concurrency exception occurred while deleting roles.", ex);
            }

            return roleId;
        }

        public async Task<IEnumerable<RoleScreenDTO>> GetAllAsync()
        {
            var result = await(from screenRole in dbContext.aSM_Z_SCREEN_ROLEs
                               join screen in dbContext.ASM_Z_SCREENs on screenRole.SCREENID equals screen.SCREENID
                               join role in dbContext.aSM_Z_ROLEs on screenRole.ROLEID equals role.ROLEID
                               select new DaihoWebAPI.Models.DTO.RoleScreenDTO
                               {
                                   //ID=asmRole.ID,
                                   SCREENID = screen.SCREENID,
                                   SCREENNAME = screen.SCREENNAME,
                                   ROLEID = role.ROLEID,
                                   ROLENAME = role.ROLENAME,
                                   SCREENACCESS = screenRole.SCREENACCESS
                               }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<RoleScreenListDTO>> GetAllListAsync()
        {
            var result = await(from screenRole in dbContext.aSM_Z_SCREEN_ROLEs
                               join screen in dbContext.ASM_Z_SCREENs on screenRole.SCREENID equals screen.SCREENID
                               join role in dbContext.aSM_Z_ROLEs on screenRole.ROLEID equals role.ROLEID
                               select new
                               {
                                   role.ROLEID,
                                   role.ROLENAME,
                                   screen.SCREENID,
                                   screen.SCREENNAME,
                                   screenRole.SCREENACCESS
                               }).ToListAsync();

            var groupedResult = result.GroupBy(r => new { r.ROLEID, r.ROLENAME })
                                      .Select(g => new RoleScreenListDTO
                                      {
                                          RoleId = g.Key.ROLEID,
                                          RoleName = g.Key.ROLENAME,
                                          ScreenAccess = g.Select(s => new ScreenAccessDTO
                                          {
                                              ScreenId = s.SCREENID,
                                              ScreenName = s.SCREENNAME,
                                              Access = s.SCREENACCESS
                                          }).ToList()
                                      }).ToList();

            return groupedResult;
        }

        public async Task<IEnumerable<RoleScreenDTO>> GetById(string id)
        {
            var result = await(from screenRole in dbContext.aSM_Z_SCREEN_ROLEs
                               join screen in dbContext.ASM_Z_SCREENs on screenRole.SCREENID equals screen.SCREENID
                               join role in dbContext.aSM_Z_ROLEs on screenRole.ROLEID equals role.ROLEID
                               where role.ROLEID == id
                               select new DaihoWebAPI.Models.DTO.RoleScreenDTO
                               {
                                   //ID=asmRole.ID,
                                   SCREENID = screen.SCREENID,
                                   SCREENNAME = screen.SCREENNAME,
                                   ROLEID = role.ROLEID,
                                   ROLENAME = role.ROLENAME,
                                   SCREENACCESS=screenRole.SCREENACCESS

                               }).ToListAsync();

            return result;
        }


    }
}
