using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.Repositories
{
    public class ASM_Z_ROLERepository : IASM_Z_ROLE
    {
        private readonly OraDbContext dbContext;

        public ASM_Z_ROLERepository(OraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ASM_Z_ROLES> CreateAsync(ASM_Z_ROLES aSM_Z_ROLES)
        {
            
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.aSM_Z_ROLEs.AddAsync(aSM_Z_ROLES);
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Utils.Errors.WrapDuplicateError(e, "duplicate role");
                }
            }
            return aSM_Z_ROLES;
        }

        public async Task<IEnumerable<ASM_Z_ROLES>> getAllSync()
        {
            return await dbContext.aSM_Z_ROLEs.ToListAsync();
        }

        public async Task<IEnumerable<ASM_Z_ROLES>> GetById(string id)
        {
            var role = await dbContext.aSM_Z_ROLEs
               .Where(item => item.ROLEID == id) // Assuming Id is the primary key property
               .ToListAsync();

            return role;
        }

        public async Task<IEnumerable<ASM_Z_ROLES>> UpdateAsync(string id, ASM_Z_ROLES roles)
        {
            var role = await dbContext.aSM_Z_ROLEs
               .Where(item => item.ROLEID == id) // Assuming Id is the primary key property
               .ToListAsync();

            if (role == null || !role.Any())
            {
                return null; // If no role(s) found, return null
            }

            foreach (var eachRole in role)
            {
                eachRole.ROLENAME = roles.ROLENAME;
                eachRole.UPDATEDDATE = DateTime.Now;

            }
            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return the updated role(s)
            return role;
        }

        public async Task<IEnumerable<ASM_Z_ROLES>> deleteAsync(string id)
        {
            var role = await dbContext.aSM_Z_ROLEs
               .Where(item => item.ROLEID == id) // Assuming Id is the primary key property
               .ToListAsync();

            if (role == null || !role.Any())
            {
                return null; // If no role(s) found, return null
            }
            foreach (var roleDel in role)
            {
                dbContext.aSM_Z_ROLEs.Remove(roleDel);
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return role;
        }
    }
}


