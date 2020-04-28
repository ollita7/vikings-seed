using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Viking.DataAccess
{
    public class VikingContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public VikingContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["Database:SqlConnection"]);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(us =>
                       {
                           us.HasKey(x => x.id);
                           us.Property(x => x.password).HasMaxLength(150);
                           us.Property(x => x.username).HasMaxLength(50);
                           us.Property(x => x.email).HasMaxLength(50);
                           us.Property(x => x.token).HasMaxLength(150);
                           us.Property(x => x.createdAt).HasDefaultValue(DateTime.Now);
                           us.Property(x => x.updatedAt).HasDefaultValue(DateTime.Now);
                           us.Property(x => x.active).HasColumnType("bit").HasDefaultValue(1);
                       });
        }

        public DbSet<Users> Users { get; set; }
    }
}