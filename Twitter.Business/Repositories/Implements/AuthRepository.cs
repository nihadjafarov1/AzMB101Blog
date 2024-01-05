using Twitter.Business.Repositories.Interfaces;
using Twitter.Core.Entities;
using Twitter.DAL.Contexts;

namespace Twitter.Business.Repositories.Implements
{
    public class AuthRepository : GenericRepository<AppUser>, IAuthRepository
    {
        public AuthRepository(TwitterContext context) : base(context)
        {
        }
    }
}
