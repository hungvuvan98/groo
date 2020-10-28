using DAL.IRepositories;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IOrderDetailRepository _orderDetail;
        private IOrderRepository _order;
        private IProductRepository _product;
        private IProviderRepository _provider;
        private IUserRepository _user;

        public UnitOfWork(AppDbContext appContext)
        {
            _context = appContext;
        }

        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if (_orderDetail == null)
                    _orderDetail = new OrderDetailRepository(_context);

                return _orderDetail;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(_context);

                return _order;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_context);

                return _product;
            }
        }

        public IProviderRepository Provider
        {
            get
            {
                if (_provider == null)
                    _provider = new ProviderRepository(_context);

                return _provider;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context);

                return _user;
            }
        }

        public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
    }
}