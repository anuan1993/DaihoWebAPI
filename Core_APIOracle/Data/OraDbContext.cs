using Core_APIOracle.Models;
using DaihoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DaihoWebAPI.Data
{
    public class OraDbContext : DbContext
    {
        public OraDbContext()
        {
        }

        public OraDbContext(DbContextOptions<OraDbContext> options) : base(options)
        {

        }
        public DbSet<ProductsInfo> Products { get; set; }
        public DbSet<custItemCd> custItemCds { get; set; }
        public DbSet<HM_TOKUIH_ALL> Tokuihs { get; set; }
        public DbSet<MANUFACTURE_PRINT_LABEL> MANUFACTURE_PRINT_LABEL { get; set; }
        public DbSet<PrintLabel> ST_ORDER_ALLs { get; set; }
        public DbSet<StTounyuAll> Tounyus { get; set; }
        public DbSet<WmUser> Users { get; set; }
        public DbSet<ASM_Z_ROLES> aSM_Z_ROLEs { get; set; }
        public DbSet<userRole> UserRoles { get; set; }
        public DbSet<ASM_Z_SCREEN> ASM_Z_SCREENs { get; set; }
        public DbSet<ASM_Z_SCREEN_ROLE> aSM_Z_SCREEN_ROLEs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HM_TOKUIH_ALL>()
                .HasKey(t => new { t.ITM_CD, t.CO_CD,t.CST_CD}); // Define your composite key properties here
            modelBuilder.Entity<PrintLabel>()
                .HasKey(t => new { t.CO_CD, t.BR_NO, t.ORD_NO }); // Define your composite key properties here
            modelBuilder.Entity<StTounyuAll>()
                .HasKey(t => new { t.CO_CD, t.INPT_NO });
            modelBuilder.Entity<WmUser>(entity =>
            {
               
            });
            modelBuilder.Entity<ASM_Z_SCREEN_ROLE>()
                           .HasKey(t => new { t.SCREENID, t.ROLEID});

        }
    }
}
