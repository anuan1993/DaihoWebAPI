using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.TempContext;

public partial class oraDBContext : DbContext
{
    public oraDBContext()
    {
    }

    public oraDBContext(DbContextOptions<oraDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsmPRackMovement> AsmPRackMovements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=DHI_TEST;Password=DHI_TEST;Data Source=192.168.0.36:1523/mcf19");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("DHI_TEST")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<AsmPRackMovement>(entity =>
        {
            entity.HasKey(e => new { e.MovementId, e.CoCd }).HasName("ASM_P_RACK_MOVEMENT_PK");

            entity.ToTable("ASM_P_RACK_MOVEMENT");

            entity.Property(e => e.MovementId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MOVEMENT_ID");
            entity.Property(e => e.CoCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CO_CD");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("DATE")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.DescRackCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DESC_RACK_CD");
            entity.Property(e => e.DestCompanyCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEST_COMPANY_CD");
            entity.Property(e => e.DestLocCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEST_LOC_CD");
            entity.Property(e => e.Isactived)
                .HasDefaultValueSql("1 ")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ISACTIVED");
            entity.Property(e => e.MovementDate)
                .HasColumnType("DATE")
                .HasColumnName("MOVEMENT_DATE");
            entity.Property(e => e.MovementReason)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("MOVEMENT_REASON");
            entity.Property(e => e.MovementStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MOVEMENT_STATUS");
            entity.Property(e => e.MovementType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MOVEMENT_TYPE");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.RevNo)
                .HasColumnType("NUMBER")
                .HasColumnName("REV_NO");
            entity.Property(e => e.ScrCompanyCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SCR_COMPANY_CD");
            entity.Property(e => e.SrcLocCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SRC_LOC_CD");
            entity.Property(e => e.SrcRackCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SRC_RACK_CD");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("DATE")
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");
        });
        modelBuilder.HasSequence("HSEQ_J0001_ACDN");
        modelBuilder.HasSequence("HSEQ_J0001_IFDN");
        modelBuilder.HasSequence("HSEQ_J0001_JCHU");
        modelBuilder.HasSequence("HSEQ_J0001_JSDN");
        modelBuilder.HasSequence("HSEQ_J0001_SHSCD");
        modelBuilder.HasSequence("HSEQ_MCFADM_ACDN");
        modelBuilder.HasSequence("HSEQ_MCFADM_IFDN");
        modelBuilder.HasSequence("HSEQ_MCFADM_JCHU");
        modelBuilder.HasSequence("HSEQ_MCFADM_JSDN");
        modelBuilder.HasSequence("HSEQ_MCFADM_SHSCD");
        modelBuilder.HasSequence("MWS_BINARY").IsCyclic();
        modelBuilder.HasSequence("SSEQ_J0001_ACIFACT");
        modelBuilder.HasSequence("SSEQ_J0001_ACIFINV");
        modelBuilder.HasSequence("SSEQ_J0001_ACIFTRN");
        modelBuilder.HasSequence("SSEQ_J0001_ACIFWIP");
        modelBuilder.HasSequence("SSEQ_J0001_BOMUPD");
        modelBuilder.HasSequence("SSEQ_J0001_DNP");
        modelBuilder.HasSequence("SSEQ_J0001_HIKK");
        modelBuilder.HasSequence("SSEQ_J0001_HRI");
        modelBuilder.HasSequence("SSEQ_J0001_NKJIS");
        modelBuilder.HasSequence("SSEQ_J0001_TNU");
        modelBuilder.HasSequence("SSEQ_J0001_UCAPV");
        modelBuilder.HasSequence("SSEQ_MCFADM_ACIFACT");
        modelBuilder.HasSequence("SSEQ_MCFADM_ACIFINV");
        modelBuilder.HasSequence("SSEQ_MCFADM_ACIFTRN");
        modelBuilder.HasSequence("SSEQ_MCFADM_ACIFWIP");
        modelBuilder.HasSequence("SSEQ_MCFADM_BOMUPD");
        modelBuilder.HasSequence("SSEQ_MCFADM_DNP");
        modelBuilder.HasSequence("SSEQ_MCFADM_HIKK");
        modelBuilder.HasSequence("SSEQ_MCFADM_HRI");
        modelBuilder.HasSequence("SSEQ_MCFADM_NKJIS");
        modelBuilder.HasSequence("SSEQ_MCFADM_TNU");
        modelBuilder.HasSequence("SSEQ_MCFADM_UCAPV");
        modelBuilder.HasSequence("USERROLESEQ");
        modelBuilder.HasSequence("WS_ACTION_ID").IsCyclic();
        modelBuilder.HasSequence("WS_APPROVAL").IsCyclic();
        modelBuilder.HasSequence("WS_CAL_SCHD").IsCyclic();
        modelBuilder.HasSequence("WS_HISTORY").IsCyclic();
        modelBuilder.HasSequence("WS_LOGIN_FRBD").IsCyclic();
        modelBuilder.HasSequence("WS_NOTICE").IsCyclic();
        modelBuilder.HasSequence("WS_PROCESS_ID").IsCyclic();
        modelBuilder.HasSequence("WS_PSNLZ_GROUP").IsCyclic();
        modelBuilder.HasSequence("WS_RIREKI").IsCyclic();
        modelBuilder.HasSequence("WS_SCR_PSNLZ").IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
