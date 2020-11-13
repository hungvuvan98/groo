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
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "2",
                    FullName = "Nguyen Minh Duc",
                  
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "3",
                    FullName = "Nhân viên 1",
                  
                    Password = "12345678",
                    Birthday = DateTime.Today,
                    Status = Status.Active
                });
                _context.Users.Add(new Entities.User()
                {
                    Id = "4",
                    FullName = "Nhân viên 2",
                  
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

            if (!_context.ProductCategories.Any())
            {
                _context.ProductCategories.Add(new Entities.ProductCategory()
                {
                    Id = "1",
                    Name = "Honda category",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                }); ;
                _context.ProductCategories.Add(new Entities.ProductCategory()
                {
                    Id = "2",
                    Name = "Wave category",
                    CreatedDate = DateTime.UtcNow,
                    Status = Status.Active
                });
                _context.ProductCategories.Add(new Entities.ProductCategory()
                {
                    Id = "3",
                    Name = "SH category",
                    CreatedDate = DateTime.UtcNow,
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
                    ProviderId = "1",
                    ProductCategoryId="1",
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
                    ProviderId = "1",
                    ProductCategoryId="1",
                    Status = Status.Active
                });
                _context.Products.Add(new Entities.Product()
                {
                    Id = "4",
                    Name = "Xích xe",
                    PriceIn = 40000,
                    PriceOut = 150000,
                    PromotionPrice = 0,
                    Wanrranty = 3,
                    Image = "this is url of image",
                    ProviderId = "3",
                    ProductCategoryId="3",
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
                    ProviderId = "2",
                    ProductCategoryId="2",
                    Status = Status.Active
                });         
            }

            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Entities.Role()
                {
                   Id="1",
                   Name="Admin",
                   Description="this is admin role",
                   Status=Status.Active
                });

                _context.Roles.Add(new Entities.Role()
                {
                    Id = "2",
                    Name = "Accountant",
                    Description = "this is accountant role",
                    Status = Status.Active
                });
                _context.Roles.Add(new Entities.Role()
                {
                    Id = "3",
                    Name = "Employee",
                    Description = "this is Employee role",
                    Status = Status.Active
                });

            }
            if (!_context.UserRoles.Any())
            {
                _context.UserRoles.Add(new Entities.UserRole()
                {
                    UserId="1",RoleId="1"
                });

                _context.UserRoles.Add(new Entities.UserRole()
                {
                    UserId = "2",
                    RoleId = "2"
                });
                _context.UserRoles.Add(new Entities.UserRole()
                {
                    UserId = "3",
                    RoleId = "3"
                });
                _context.UserRoles.Add(new Entities.UserRole()
                {
                    UserId = "4",
                    RoleId = "3"
                });
               
            }
            await _context.SaveChangesAsync();
        }
    }
}