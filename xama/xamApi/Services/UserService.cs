using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using xamApi.Helpers;
using xamApi.Models;

namespace xamApi.Services
{
    public interface IUserService
    {
        UserModel LoginUser(string username, string password);
        UserModel Create(UserModel user, string password);
        UserModel GetById(int id);
        void Delete(int id);
        void UpdateUser(UserModel user, string password = null);
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

        public UserModel LoginUser(string username, string password)
        {
          if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return null;

          var user = _context.Users.SingleOrDefault(x => x.Username == username);

          // check if username exists
          if (user == null)
            return null;

          // check if password is correct
          if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

          return user;
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

            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
          if (password == null) throw new ArgumentNullException("Password can't be empty or equal to null");
          if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty or whitespace only string.", "password");
          if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
          if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

          using (var hmac = new HMACSHA512(storedSalt))
          {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
              if (computedHash[i] != storedHash[i]) return false;
            }
          }

          return true;
        }

    public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return;
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public UserModel GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void UpdateUser(UserModel userlModel, string password = null)
        {
            var user = _context.Users.Find(userlModel.Id);

            if (user == null) throw new Exception("User not found");

            if (!string.IsNullOrWhiteSpace(userlModel.Username) && userlModel.Username != user.Username)
            {
                if (_context.Users.Any(x => x.Username == userlModel.Username))
                    throw new Exception("Username " + userlModel.Username + " is already taken");

                user.Username = userlModel.Username;
            }

            if (!string.IsNullOrWhiteSpace(userlModel.FirstName))
                user.FirstName = userlModel.FirstName;

            if (!string.IsNullOrWhiteSpace(userlModel.LastName))
                user.LastName = userlModel.LastName;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
