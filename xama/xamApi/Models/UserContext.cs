using Microsoft.EntityFrameworkCore;

namespace xamApi.Models
{
  public class UserContext : DbContext
  {
    public DbSet<UserModel> Users { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
