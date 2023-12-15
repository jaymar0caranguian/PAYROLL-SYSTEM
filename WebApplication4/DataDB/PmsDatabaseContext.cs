using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.DataDB;

namespace WebApplication4.DataDB;

public partial class PmsDatabaseContext : DbContext
{
    public PmsDatabaseContext()
    {
    }

    public PmsDatabaseContext(DbContextOptions<PmsDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attd> Attds { get; set; }

    public virtual DbSet<Dd> Dds { get; set; }

    public virtual DbSet<EmpInfo> EmpInfos { get; set; }

    public virtual DbSet<P> Ps { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<SysAcc> SysAccs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=QCU;Initial Catalog=PMS_DATABASE;Integrated Security=True; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attd>(entity =>
        {
            entity.ToTable("ATTD");

            entity.HasIndex(e => e.EmpId, "IX_ATTD");

            entity.Property(e => e.AttdId).HasColumnName("ATTD_ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
            entity.Property(e => e.nd).HasColumnName("nd");
            entity.Property(e => e.St).HasColumnName("ST");
            entity.Property(e => e.Tr).HasColumnName("TR");
        });

        modelBuilder.Entity<Dd>(entity =>
        {
            entity.ToTable("DD");

            entity.Property(e => e.DdId).HasColumnName("DD_ID");
            entity.Property(e => e.Ddname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DDName");
        });

        modelBuilder.Entity<EmpInfo>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Emp_INFO");

            entity.Property(e => e.EmpId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Emp_ID");
            //entity.Property(e => e.DdId).HasColumnName("DD_ID");
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LName");
            entity.Property(e => e.Mname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MName");
            entity.Property(e => e.PagibigNo).HasColumnName("PAGIBIG_NO");
            entity.Property(e => e.Position)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PositionId).HasColumnName("Position_ID");
            entity.Property(e => e.SssNo).HasColumnName("SSS_NO");

            //entity.HasOne(d => d.Dd).WithMany(p => p.EmpInfos)
            //    .HasForeignKey(d => d.DdId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Emp_INFO_DD");

            entity.HasOne(d => d.Emp).WithOne(p => p.EmpInfo)
                .HasPrincipalKey<Attd>(p => p.EmpId)
                .HasForeignKey<EmpInfo>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emp_INFO_ATTD");

            entity.HasOne(d => d.EmpNavigation).WithOne(p => p.EmpInfo)
                .HasPrincipalKey<P>(p => p.EmpId)
                .HasForeignKey<EmpInfo>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emp_INFO_PS");

            entity.HasOne(d => d.PositionNavigation).WithMany(p => p.EmpInfos)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emp_INFO_Position");
        });

        modelBuilder.Entity<P>(entity =>
        {
            entity.HasKey(e => e.PsId);

            entity.ToTable("PS");

            entity.HasIndex(e => e.EmpId, "IX_PS").IsUnique();

            entity.HasIndex(e => e.DdId, "IX_PS_1").IsUnique();

            entity.HasIndex(e => e.AttdId, "IX_PS_2").IsUnique();

            entity.Property(e => e.PsId).HasColumnName("PS_ID");
            entity.Property(e => e.AttdId).HasColumnName("ATTD_ID");
            entity.Property(e => e.DdId).HasColumnName("DD_ID");
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK_Position_ID");

            entity.ToTable("Position");

            entity.Property(e => e.PositionId).HasColumnName("Position_ID");
            entity.Property(e => e.Position1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Position");
        });

        modelBuilder.Entity<SysAcc>(entity =>
        {
            entity.ToTable("sys_acc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Pass).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Mname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Rate).HasMaxLength(50);
            entity.Property(e => e.SssNo).HasMaxLength(50);
            entity.Property(e => e.PagibigNo).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<WebApplication4.DataDB.Employee> Employee { get; set; } = default!;
    public object Deductions { get; internal set; }
}
