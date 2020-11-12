using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Export> Orders { get; set; }

        public DbSet<ExportDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Export>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__Export");

                entity.ToTable("Exports");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.CustomerName)
                   .HasColumnName("CustomerName")
                   .HasMaxLength(200);

                entity.Property(e => e.CustomerPhone)
                  .HasColumnName("CustomerPhone")
                  .HasMaxLength(15);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Exports)
                      .HasForeignKey(d => d.CreatedByUserId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ExportDetail>(entity =>
            {
                entity.HasKey(e => new { e.ExportId, e.ProductId, e.ProviderId })
                      .HasName("PK__ExportDetail");

                entity.ToTable("ExportDetails");

                entity.Property(e => e.ExportId)
                  .HasColumnName("ExportId")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.ProductId)
                   .HasColumnName("ProductId")
                   .HasMaxLength(10)
                   .IsRequired();

                entity.Property(e => e.ProviderId)
                   .HasColumnName("ProviderId")
                   .HasMaxLength(10)
                   .IsRequired();

                entity.HasOne(d => d.Export)
                      .WithMany(p => p.ExportDetails)
                      .HasForeignKey(d => d.ExportId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Product)
                      .WithMany(p => p.ExportDetails)
                      .HasForeignKey(d => new { d.ProductId, d.ProviderId })
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK__product__exportdetail11");
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__Import");

                entity.ToTable("Imports");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Imports)
                      .HasForeignKey(d => d.CreatedByUserId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.HasKey(e => new { e.ImportId, e.ProductId, e.ProviderId })
                      .HasName("PK__ImportDetail");

                entity.ToTable("ImportDetails");

                entity.Property(e => e.ImportId)
                  .HasColumnName("ImportId")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.ProductId)
                   .HasColumnName("ProductId")
                   .HasMaxLength(10).IsRequired();

                entity.Property(e => e.ProviderId)
                   .HasColumnName("ProviderId")
                   .HasMaxLength(10).IsRequired();

                entity.HasOne(d => d.Import)
                      .WithMany(p => p.ImportDetails)
                      .HasForeignKey(d => d.ImportId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Product)
                      .WithMany(p => p.ImportDetails)
                      .HasForeignKey(d => new { d.ProductId, d.ProviderId })
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK__product__importdetail");
                
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProviderId })
                      .HasName("PK__product");

                entity.ToTable("Products");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.ProviderId)
                  .HasColumnName("ProviderId")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.ProductCategoryId)
                  .HasColumnName("ProductCategoryId")
                  .HasMaxLength(10);

                entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .HasMaxLength(300);

                entity.Property(e => e.PriceIn)
                   .IsRequired();

                entity.Property(e => e.PriceOut)
                  .IsRequired();

                entity.HasOne(d => d.Provider)
                      .WithMany(p => p.Products)
                      .HasForeignKey(d => d.ProviderId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ProductCategory)
                      .WithMany(p => p.Products)
                      .HasForeignKey(d => d.ProductCategoryId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__ProductCategory");

                entity.ToTable("ProductCategories");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10);

                entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .HasMaxLength(300);             

            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__Provider");

                entity.ToTable("Providers");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .HasMaxLength(300)
                  .IsRequired();

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__role");

                entity.ToTable("Roles");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10);

                entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .HasMaxLength(300).IsRequired();

            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e =>new { e.RoleId, e.UserId })
                      .HasName("PK__UserRole");

                entity.ToTable("UserRoles");

                entity.Property(e => e.RoleId)
                  .HasColumnName("RoleId")
                  .HasMaxLength(10);

                entity.Property(e => e.UserId)
                   .HasColumnName("UserId")
                   .HasMaxLength(10);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.UserRoles)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Role)
                      .WithMany(p => p.UserRoles)
                      .HasForeignKey(d => d.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__user");

                entity.ToTable("Users");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10);

                entity.Property(e => e.FullName)
                   .HasColumnName("FullName")
                   .IsRequired()
                   .HasMaxLength(200);

                entity.Property(e => e.Birthday)
                  .HasColumnName("Birthday")
                  .HasMaxLength(30);

                entity.Property(e => e.Phone)
                  .HasColumnName("Phone")
                  .HasMaxLength(15);

                entity.Property(e => e.Password)
                  .HasColumnName("Password")
                  .IsRequired()
                  .HasMaxLength(15);

                entity.Property(e => e.Email)
                 .HasColumnName("Email")
                 .HasMaxLength(50);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.UserId)
                      .HasName("PK__salary");

                entity.ToTable("Salaries");

                entity.Property(e => e.UserId)
                  .HasColumnName("UserId")
                  .HasMaxLength(10);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Salaries)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ProviderId })
                      .HasName("PK__warehouse");

                entity.ToTable("Warehouses");

                entity.Property(e => e.ProviderId)
                  .HasColumnName("ProviderId")
                  .HasMaxLength(10);

                entity.Property(e => e.ProductId)
                  .HasColumnName("ProductId")
                  .HasMaxLength(10);

                entity.HasOne(d => d.Product)
                      .WithMany(p => p.Warehouses)
                      .HasForeignKey(d =>new { d.ProductId, d.ProviderId })
                      .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}