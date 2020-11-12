using DAL.Entities;
using DAL.Infrastructures;
using DAL.IRepositories;

namespace DAL.Repositories
{
    public class OrderRepository : Repository<Export>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appContext => (AppDbContext)_context;
    }
}