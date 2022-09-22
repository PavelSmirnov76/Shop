using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace GameStore.Database
{
    public class GameStoreContext : IdentityDbContext<User>
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();             
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductInfo> ProductInfos => Set<ProductInfo>();
        public DbSet<BasketProduct> BasketProducts => Set<BasketProduct>();
        public DbSet<Basket> Baskets => Set<Basket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(p =>
            {
                p
                 .HasMany(p => p.ProductInfos)
                 .WithOne(pi => pi.Product);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(u => u.Basket);
            });

            modelBuilder.Entity<Basket>()
                .HasMany(p => p.Products)
                .WithMany(b => b.Baskets)
                .UsingEntity<BasketProduct>(
                    j => j
                        .HasOne(p => p.Product)
                        .WithMany(bp => bp.BasketProducts)
                        .HasForeignKey(p => p.ProductId),
                    j => j
                        .HasOne(b => b.Basket)
                        .WithMany(bp => bp.BasketProducts)
                        .HasForeignKey(b => b.BasketId),
                    j => j
                        .HasKey(bp => new {bp.ProductId, bp.BasketId})
                );
        }
    }
}
