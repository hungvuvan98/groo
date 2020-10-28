using DAL.Entities;
using DAL.Infrastructures;
using DAL.IRepositories;

namespace DAL.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appContext => (AppDbContext)_context;
    }
}