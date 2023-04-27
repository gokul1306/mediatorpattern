using Mediator_pattern.Models;

namespace Mediator_pattern.Repo
{
    public class UserDal{
        private readonly PDbcontext _context;
        public UserDal(PDbcontext context)
        {
            _context = context;
        }
        public User CheckUser(string Email,string Password)
        {
              _context.User.Any(x=>x.Email==Email && x.Password==Password);
              var user = _context.User.Where(x=>x.Email==Email && x.Password==Password).First();
              return user;
        }

    }
}