using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebMineSweeper.Models
{
    public partial class minebaseContext : DbContext
    {
        public minebaseContext()
        {
        }

        public minebaseContext(DbContextOptions<minebaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)

            {

                IConfigurationRoot configuration = new ConfigurationBuilder()

                .SetBasePath(Directory.GetCurrentDirectory())

                            .AddJsonFile("appsettings.json")

                            .Build();

                var connectionString = "Server=127.0.0.1;Port=3307;Database=minebase;Uid=root;Pwd=root;";

                optionsBuilder.UseMySQL(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "unique_email")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "unique_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EasyTime).HasColumnName("easy_time");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.HardTime).HasColumnName("hard_time");

                entity.Property(e => e.MediumTime).HasColumnName("medium_time");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
