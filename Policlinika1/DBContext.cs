using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Policlinika;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Talon> Talons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Policlinika\\ClinicReception.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor);

            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("FIO");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsFixedLength();
            entity.Property(e => e.Type).HasColumnType("text");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient);

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("FIO");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsFixedLength();
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Talon>(entity =>
        {
            entity.HasKey(e => e.IdTalon);

            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Number)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Talons)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Talons_Doctors");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Talons)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Talons_Patients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
