using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using xamApi.Models;

namespace xamApi.Helpers
{
  public class DataContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      // connect to sql server database
      options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<UserModel> Users { get; set; }
  }
}