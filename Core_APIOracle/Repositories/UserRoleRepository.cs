using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using DaihoWebAPI.Models;
using System.Data;
using DaihoWebAPI.Utilities;
using DaihoWebAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace DaihoWebAPI.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly OraDbContext dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration configuration;

        public UserRoleRepository(OraDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("OraDbConnection");
        }

        public async Task<userRole> CreateAsync(userRole UserRole)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                   
                    await dbContext.UserRoles.AddAsync(UserRole);
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Utils.Errors.WrapDuplicateError(e, "failed on save");
                }
            }
            return UserRole;
        }

        public async Task<IEnumerable<userRole>> deleteAsync(UserRolesDTO userRoles)
        {
            var role = await dbContext.UserRoles
             .Where(item => item.USERID == userRoles.USERID && item.ROLEID == userRoles.ROLEID) // Assuming Id is the primary key property
             .ToListAsync();

            if (role == null || !role.Any())
            {
                return null; // If no role(s) found, return null
            }
            foreach (var roleDel in role)
            {
                dbContext.UserRoles.Remove(roleDel);
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return role;

        }


        public async Task<IEnumerable<DaihoWebAPI.Models.DTO.UserRolesDTO>> GetAllAsync()

        {

            //return await dbContext.UserRoles.Include("ASM_Z_ROLES").Include("WmUser").ToListAsync();

            var result = await (from role in dbContext.aSM_Z_ROLEs
                                join asmRole in dbContext.UserRoles on role.ROLEID equals asmRole.ROLEID
                                join user in dbContext.Users on asmRole.USERID equals user.USR_ID
                                select new DaihoWebAPI.Models.DTO.UserRolesDTO
                                {
                                    //ID=asmRole.ID,
                                    ROLEID = role.ROLEID,
                                    USERNAME = user.USR_NM,
                                    USERID = user.USR_ID,
                                    ROLENAME = role.ROLENAME,
                                    ID=asmRole.ID,
                                   

                                }).ToListAsync();

            return result;
        }


        public async Task<IEnumerable<userRole>> UpdateAsync(int id, RoleIdDto userRoles)
        {
            var userRole = await dbContext.UserRoles
                 .Where(item => item.ID == id) // Assuming Id is the primary key property
                 .ToListAsync();

            if (userRole == null || !userRole.Any())
            {
                return null; // If no role(s) found, return null
            }

            foreach (var eachRole in userRole)
            {
               // eachRole.USERID = userRoles.USERID;
                eachRole.ROLEID = userRoles.roleID;


            }
            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return the updated role(s)
            return userRole;
        }

        public async Task<IEnumerable<UserRolesDTO>> GetUserAsync()
        {

            var result = await (from user in dbContext.Users
                                select new DaihoWebAPI.Models.DTO.UserRolesDTO
                                {
                                    //ID=asmRole.ID,
                                    
                                    USERNAME = user.USR_NM,
                                    USERID = user.USR_ID,
                                    

                                }).ToListAsync();

            return result;
        }

    }
}
