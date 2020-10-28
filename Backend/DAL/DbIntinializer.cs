using DAL.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class DbIntinializer
    {
        private readonly AppDbContext _context;

        public DbIntinializer(AppDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new Entities.User()
                {
                    Id = "1",
                    FullName = "Hung Vu Van",
                    Role = "Administrator",
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "2",
                    FullName = "Nguyen Minh Duc",
                    Role = "Accountant",
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "3",
                    FullName = "Nhân viên 1",
                    Role = "Emloyee",
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "4",
                    FullName = "Nhân viên 2",
                    Role = "Emloyee",
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
            }

            if (!_context.Providers.Any())
            {
                _context.Providers.Add(new Entities.Provider()
                {
                    Id = "1",
                    Name = "Honda",
                    Status = Status.Active
                });
                _context.Providers.Add(new Entities.Provider()
                {
                    Id = "2",
                    Name = "Wave",
                    Status = Status.Active
                });
                _context.Providers.Add(new Entities.Provider()
                {
                    Id = "3",
                    Name = "SH",
                    Status = Status.Active
                });
            }
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Entities.Product()
                {
                    Id = "1",
                    Name = "Lốp xe",
                    PriceIn = 50000,
                    PriceOut = 200000,
                    PromotionPrice = 0,
                    Wanrranty = 3,
                    Image = "this is url of image",
                    Quantity = 100,
                    ProviderId = "1",
                    Status = Status.Active
                });
                _context.Products.Add(new Entities.Product()
                {
                    Id = "3",
                    Name = "Xích xe",
                    PriceIn = 40000,
                    PriceOut = 150000,
                    PromotionPrice = 0,
                    Wanrranty = 3,
                    Image = "this is url of image",
                    Quantity = 100,
                    ProviderId = "1",
                    Status = Status.Active
                });
                _context.Products.Add(new Entities.Product()
                {
                    Id = "2",
                    Name = "Yên xe",
                    PriceIn = 50000,
                    PriceOut = 100000,
                    PromotionPrice = 0,
                    Wanrranty = 6,
                    Image = "this is url of image",
                    Quantity = 200,
                    ProviderId = "1",
                    Status = Status.Active
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}