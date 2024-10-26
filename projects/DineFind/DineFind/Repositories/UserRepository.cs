using DineFind.Models;
using DineFind.Models.Entities;
using System.Linq;

namespace DineFind.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DineFindBdContext _context;

        // Constructor injection of the DineFindBdContext
        public UserRepository(DineFindBdContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void UpdatePreferences(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Preferences = user.Preferences;
                _context.SaveChanges();
            }
        }
    }
}