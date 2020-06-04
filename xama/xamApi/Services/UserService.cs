using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xamApi.Helpers;
using xamApi.Models;

namespace xamApi.Services
{
  public interface IUserService
  {
  }

  public class UserService : IUserService
  {
    private DataContext context;

    public UserService(DataContext _context)
    {
      context = _context;
    }

    public IEnumerable<UserModel> GetAll()
    {
      return context.Users;
    }
  }
}
