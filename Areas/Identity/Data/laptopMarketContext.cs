using laptopMarket.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Data;

public class laptopMarketContext : IdentityDbContext<IdentityUser>
{
    public laptopMarketContext(DbContextOptions<laptopMarketContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Cart_table> Cart_tables { get; set; }
    public DbSet<Cart_item> Cart_items { get; set; }
    public DbSet<Order_table> Order_tables { get; set; }
    public DbSet<Warehouse_pro_qu> Warehouse_pro_qus { get; set; }
    public DbSet<AppUser> AppUser { get; set; }
   public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Copon> Copons { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
