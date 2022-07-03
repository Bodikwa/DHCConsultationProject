using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DHC.DAL.Models
{
    public partial class DHCConsultingDBContext : DbContext
    {
        public DHCConsultingDBContext()
        {
        }

        public DHCConsultingDBContext(DbContextOptions<DHCConsultingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<ModelCarCode> ModelCarCodes { get; set; }
        public virtual DbSet<ModelCarName> ModelCarNames { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=DHCConsultingDB;Username=postgres;Password=Pedmond@63");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ModelCode)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Car_ModelCodeId_fkey");

                entity.HasOne(d => d.ModelName)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Car_ModelNameId_fkey");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerContact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ModelCarCode>(entity =>
            {
                entity.HasKey(e => e.ModelCodeId)
                    .HasName("ModelCarCode_pkey");

                entity.ToTable("ModelCarCode");

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ModelCarName>(entity =>
            {
                entity.HasKey(e => e.ModelNameId)
                    .HasName("ModelCarName_pkey");

                entity.ToTable("ModelCarName");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserContact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserLocation)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_CarId_fkey");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_ManagerId_fkey");

                entity.HasOne(d => d.ModelCode)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ModelCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_ModelCodeId_fkey");

                entity.HasOne(d => d.ModelName)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ModelNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_ModelNameId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
