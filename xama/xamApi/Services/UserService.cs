using System;
using System.Collections.Generic;
using System.Linq;
using xamApi.Helpers;
using xamApi.Models;
using System.Security.Cryptography;

namespace xamApi.Services
{
  public interface IUserService
  {
    UserModel Create(UserModel user, string password);
    UserModel GetById(int id);
    void Delete(int id);
  }
  public class UserService : IUserService
  {
    private DataContext _context;

    public UserService(DataContext context)
    {
      _context = context;
    }

    public IEnumerable<UserModel> GetAll()
    {
      return _context.Users;
    }

    public UserModel Create(UserModel user, string password)
    {
      if (string.IsNullOrWhiteSpace(password))
        throw new Exception("Password is required");
      if (_context.Users.Any(x => x.Username == user.Username))
        throw new Exception("Username \"" + user.Username + "\" is already taken");

      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      _context.Users.Add(user);
      _context.SaveChanges();

      return user;
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

      using (HMACSHA512 hmac = new HMACSHA512())
      {
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        passwordSalt = hmac.Key;
      }
    }

    public void Delete(int id)
    {
      UserModel user = _context.Users.Find(id);
      if (user == null) return;
      _context.Users.Remove(user);
      _context.SaveChanges();
    }

    public UserModel GetById(int id)
    {
      return _context.Users.Find(id);
    }
  }
}
