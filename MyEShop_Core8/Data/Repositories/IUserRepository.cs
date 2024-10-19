using MyEShop_Core8.Models;
using System.Linq;

namespace MyEShop_Core8.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        void AddUser(Users user);
        Users GetUserForLogin(string email, string password);
    }



    public class UserRepository : IUserRepository
    {
        private MyEShopContext _context;

        public UserRepository(MyEShopContext context)
        {
            _context = context;
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.users.SingleOrDefault(c=> c.Email == email && c.Password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.users.Any(u => u.Email == email);
        }
    }
}
