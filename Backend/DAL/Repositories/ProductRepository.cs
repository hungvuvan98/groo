using DAL.Entities;
using DAL.Infrastructures;
using DAL.IRepositories;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appContext => (AppDbContext)_context;
    }
}