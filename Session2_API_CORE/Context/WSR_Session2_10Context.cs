using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Session2_API_CORE.Models;

#nullable disable

namespace Session2_API_CORE.Context
{
    public partial class WSR_Session2_10Context : DbContext
    {
        public WSR_Session2_10Context()
        {
        }

        private readonly IConfiguration _configuration;

        public WSR_Session2_10Context(DbContextOptions<WSR_Session2_10Context> options, IConfiguration configuration)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<CameraLoad> CameraLoads { get; set; }
        public virtual DbSet<LoyaltyCard> LoyaltyCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=laptop-gtkgdtgs\\nikitaserver;Initial Catalog=WSR_Session2_10;Integrated Security=True");
                //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultCS"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CameraLoad>(entity =>
            {
                entity.ToTable("CameraLoad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.StateNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("state_number");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<LoyaltyCard>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardHolder).IsUnicode(false);

                entity.Property(e => e.LoyaltyСard)
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
