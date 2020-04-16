using System;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using RealEstate.Domain.IdentityModels;
using RealEstate.Domain.Models;

namespace RealEstate.Domain.Context
{
    public partial class RealEstateDBContext : IdentityDbContext<ApplicationUser>
    {
        public RealEstateDBContext()
        {
        }

        public RealEstateDBContext(DbContextOptions<RealEstateDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProclamationTypes> ProclamationTypes { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../RealEstate.API/appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("RealEstateDBConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProclamationTypes>(entity =>
            {
                entity.HasKey(e => e.ProclamationTypeId)
                    .HasName("PK__Proclama__B94C0E017A0CE1CD");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK__District__B94C0E017A0CE1CD");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.CodDistrict)
                .IsRequired()
                .HasMaxLength(30);
            });

            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
