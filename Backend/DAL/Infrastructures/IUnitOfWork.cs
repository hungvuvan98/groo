using DAL.IRepositories;
using System.Threading.Tasks;

namespace DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IExportDetailRepository ExportDetail{ get; }

        IExportRepository Export { get; }

        IImportDetailRepository ImportDetail { get; }

        IImportRepository Import { get; }

        IProductRepository Product { get; }

        IProductCategoryRepository ProductCategory { get; }

        IProviderRepository Provider { get; }

        IRoleRepository Role { get; }

        ISalaryRepository Salary { get; }

        IUserRepository User { get; }

        IUserRoleRepository UserRole { get; }

        IWarehouseRepository Warehouse { get; }

        Task<int> SaveChanges();
    }
}