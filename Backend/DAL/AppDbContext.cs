using DAL.Entities;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.Role)
                  .HasColumnName("Role")
                  .IsRequired()
                  .HasMaxLength(100);

                entity.Property(e => e.Status)
                 .IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__order");

                entity.ToTable("Orders");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10);

                entity.Property(e => e.CustomerName)
                   .HasColumnName("CustomerName")
                   .HasMaxLength(200);

                entity.Property(e => e.CustomerPhone)
                  .HasColumnName("CustomerPhone")
                  .HasMaxLength(15);

                entity.Property(e => e.Status)
                  .IsRequired();

                entity.Property(e => e.PaymentMethod)
                  .IsRequired();

                entity.HasOne(d => d.Users)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(d => d.CreatedByUserId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__orderdetail");

                entity.ToTable("OrderDetails");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .HasMaxLength(10);

                entity.Property(e => e.ProductId)
                   .HasColumnName("ProductId")
                   .HasMaxLength(10);

                entity.HasOne(d => d.Order)
                      .WithMany(p => p.OrderDetails)
                      .HasForeignKey(d => d.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Product)
                      .WithMany(p => p.OrderDetails)
                      .HasForeignKey(d => d.ProductId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__product");

                entity.ToTable("Products");

                entity.Property(e => e.Id)
                  .HasColumnName("Id")
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
                      .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}