using DAL.IRepositories;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IExportDetailRepository _exportDetail;
        private IExportRepository _export;
        private IImportDetailRepository _importDetail;
        private IImportRepository _import;
        private IProductRepository _product;
        private IProductCategoryRepository _productCategory;
        private IProviderRepository _provider;
        private IRoleRepository _role;
        private ISalaryRepository _salary;
        private IUserRepository _user;
        private IUserRoleRepository _userRole;
        private IWarehouseRepository _warehouse;

        public UnitOfWork(AppDbContext appContext)=> _context = appContext;
 

        public IExportDetailRepository ExportDetail
        {
            get
            {
                if (_exportDetail == null)
                    _exportDetail = new ExportDetailRepository(_context);

                return _exportDetail;
            }
        }

        public IExportRepository Export
        {
            get
            {
                if (_export == null)
                    _export = new ExportRepository(_context);

                return _export;
            }
        }

        public IImportDetailRepository ImportDetail
        {
            get
            {
                if (_importDetail == null)
                    _importDetail = new ImportDetailRepository(_context);

                return _importDetail;
            }
        }

        public IImportRepository Import
        {
            get
            {
                if (_import == null)
                    _import = new ImportRepository(_context);

                return _import;
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

        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if (_productCategory == null)
                    _productCategory = new ProductCategoryRepository(_context);

                return _productCategory;
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

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                    _role = new RoleRepository(_context);

                return _role;
            }
        }

        public ISalaryRepository Salary
        {
            get
            {
                if (_salary == null)
                    _salary = new SalaryRepository(_context);

                return _salary;
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

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)
                    _userRole = new UserRoleRepository(_context);

                return _userRole;
            }
        }

        public IWarehouseRepository Warehouse
        {
            get
            {
                if (_warehouse == null)
                    _warehouse = new WarehouseRepository(_context);

                return _warehouse;
            }
        }
        public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
    }
}