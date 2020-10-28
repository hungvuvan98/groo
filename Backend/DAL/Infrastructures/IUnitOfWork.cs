using DAL.IRepositories;
using System.Threading.Tasks;

namespace DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IOrderDetailRepository OrderDetail { get; }

        IOrderRepository Order { get; }

        IProductRepository Product { get; }

        IProviderRepository Provider { get; }

        IUserRepository User { get; }

        Task<int> SaveChanges();
    }
}