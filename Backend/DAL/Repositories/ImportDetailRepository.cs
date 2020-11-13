using DAL.Entities;
using DAL.Infrastructures;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{

    public class ImportDetailRepository : Repository<ImportDetail>, IImportDetailRepository
    {
        public ImportDetailRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appContext => (AppDbContext)_context;
    }
}
