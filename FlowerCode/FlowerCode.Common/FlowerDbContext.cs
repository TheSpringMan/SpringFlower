using Microsoft.EntityFrameworkCore;
using FlowerCode.Model.Entity;

namespace FlowerCode.Common;
public class FlowerDbContext : DbContext
{
    public FlowerDbContext(DbContextOptions<FlowerDbContext> options):base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SpringFlowerDB;TrustServerCertificate=true;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<User> Users { get; set; }
}