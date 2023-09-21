using Microsoft.EntityFrameworkCore;
using aspnetefcore.Models;

namespace aspnetefcore.Database
{
  public class ApplicationDBContext : DbContext
  {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDBContext(
      DbContextOptions<ApplicationDBContext> options) :
      base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
      modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
      modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100);
      modelBuilder.Entity<Product>().Property(p => p.Name).IsUnicode();
    }
  }
}