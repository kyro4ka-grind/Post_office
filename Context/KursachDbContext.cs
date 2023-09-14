using System;
using System.Collections.Generic;
using Kursach_TP_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Kursach_TP_Core.Context;

public partial class KursachDbContext : DbContext
{
    public KursachDbContext()
    {
    }

    public KursachDbContext(DbContextOptions<KursachDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Sender> Senders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=DESKTOP-EVV8IKO\\MY_SERV;Database=Kursach_db;Trusted_Connection=True;TrustServerCertificate=True;");
        => optionsBuilder.UseSqlServer("WIN-HJUHREA82LG\\MY_SERVER;Database=Kursach_db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("PK__Departme__E7290D19A1501495");

            entity.Property(e => e.Index)
                .ValueGeneratedNever()
                .HasColumnName("index_");
            entity.Property(e => e.IdPlace).HasColumnName("idPlace_");
            entity.Property(e => e.IsOpen).HasColumnName("isOpen_");
            entity.Property(e => e.Operators).HasColumnName("operators_");
            entity.Property(e => e.Postmans).HasColumnName("postmans_");
            entity.Property(e => e.Workers).HasColumnName("workers_");

            entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdPlace)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Departmen__idPla__4316F928");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.IdPack).HasName("PK__Packages__5862AD212A8AD774");

            entity.Property(e => e.IdPack)
                .HasMaxLength(20)
                .HasColumnName("idPack_");
            entity.Property(e => e.IdPlaceIn).HasColumnName("idPlaceIn_");
            entity.Property(e => e.IdPlaceOut).HasColumnName("idPlaceOut_");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name_");
            entity.Property(e => e.Sender).HasColumnName("sender_");
            entity.Property(e => e.Status).HasColumnName("status_");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname_");

            entity.HasOne(d => d.IdPlaceInNavigation).WithMany(p => p.PackageIdPlaceInNavigations)
                .HasForeignKey(d => d.IdPlaceIn)
                .HasConstraintName("FK__Packages__idPlac__4D94879B");

            entity.HasOne(d => d.IdPlaceOutNavigation).WithMany(p => p.PackageIdPlaceOutNavigations)
                .HasForeignKey(d => d.IdPlaceOut)
                .HasConstraintName("FK__Packages__idPlac__4CA06362");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.Packages)
                .HasForeignKey(d => d.Sender)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Packages__sender__4E88ABD4");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Places__DC501A11B27DAD8D");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country_");
            entity.Property(e => e.Index).HasColumnName("index_");
            entity.Property(e => e.Town)
                .HasMaxLength(20)
                .HasColumnName("town_");
        });

        modelBuilder.Entity<Sender>(entity =>
        {
            entity.HasKey(e => e.PassportNum).HasName("PK__Sender__9FB50AC3D0CD1759");

            entity.ToTable("Sender");

            entity.Property(e => e.PassportNum)
                .ValueGeneratedNever()
                .HasColumnName("passportNum_");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name_");
            entity.Property(e => e.PhoneNum).HasColumnName("phoneNum_");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname_");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("PK__Users__94F8E94828DF3117");

            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login_");
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .HasColumnName("mail_");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password_");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("PK__Workers__94F8E948D2C2EC27");

            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login_");
            entity.Property(e => e.Index).HasColumnName("index_");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password_");
            entity.Property(e => e.Role).HasColumnName("role_");

            entity.HasOne(d => d.IndexNavigation).WithMany(p => p.WorkersNavigation)
                .HasForeignKey(d => d.Index)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Workers__index___45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
