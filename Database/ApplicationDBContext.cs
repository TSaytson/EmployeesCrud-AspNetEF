using Microsoft.EntityFrameworkCore;
using aspnetefcore.Models;

namespace aspnetefcore.Database
{
  public class ApplicationDBContext : DbContext
  {
    public DbSet<Employee> Employees { get; set; }
    public ApplicationDBContext(
      DbContextOptions<ApplicationDBContext> options):
      base(options){

    }
  }
}