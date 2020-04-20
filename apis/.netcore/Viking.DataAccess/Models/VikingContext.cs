using System;
using Microsoft.EntityFrameworkCore;

namespace Viking.DataAccess
{
    public class VikingContext : DbContext
    {
        public VikingContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Viking;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(us =>
                       {
                           us.HasKey(x => x.Id);
                           us.Property(x => x.Username).HasMaxLength(50);
                           us.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.Now);
                           us.Property(x => x.Active).HasColumnType("bit").HasDefaultValue(1);
                           us.Property(x => x.Mail).HasMaxLength(50);
                           us.Property(x => x.Token).HasMaxLength(150);
                       });
        }
    }
}