using Core_APIOracle.Models;
using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using DaihoWebAPI.Models.DTO;

namespace DaihoWebAPI.Repositories
{
    public class TokuihRepository : ITokuihRepository
    {
        private readonly OraDbContext dbContext;
        private readonly string _connectionString;

        public TokuihRepository(OraDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("OraDbConnection");
        }


        public async Task<HM_TOKUIH_ALL> AddSync(HM_TOKUIH_ALL tokuih)
        {

            await dbContext.AddAsync(tokuih);
            await dbContext.SaveChangesAsync();
            return tokuih;
        }

        public async Task<IEnumerable<HM_TOKUIH_ALL>> GetAllAsync()
        {
            
            return await dbContext.Tokuihs.ToListAsync() ;  //return dbContext.Tokuihs.ToList
            
        }


        public async Task<HM_TOKUIH_ALL> GetTokuihAsync(string itmCd)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Construct your SQL query
                string sql = "SELECT * FROM HM_TOKUIH_ALL WHERE ITM_CD = :ITM_CD";

                // Create a command with parameters
                using (var command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add("@ITM_CD", itmCd);

                    // Execute the command and read the result asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // Map data from the reader to your entity
                            return new HM_TOKUIH_ALL
                            {
                                // Assuming column names here, replace them with actual column names
                                ITM_CD = reader["ITM_CD"].ToString(),
                                // Map other properties accordingly
                            };
                        }
                        else
                        {
                            // No data found with the given ITM_CD
                            return null;
                        }
                    }
                }
            }
        }


    }
}
