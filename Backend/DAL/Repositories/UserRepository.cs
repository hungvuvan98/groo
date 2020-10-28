using DAL.Entities;
using DAL.Infrastructures;
using DAL.IRepositories;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appContext => (AppDbContext)_context;
    }
}