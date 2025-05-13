using Microsoft.EntityFrameworkCore;
using storeApp.Models;
namespace storeApp.Data
{
    
    public class PurchasingContext : DbContext
    {
        public PurchasingContext(DbContextOptions<PurchasingContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-many relationship: Supplier -> PurchaseOrders
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many: PurchaseOrder -> PurchaseOrderDetails
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(d => d.PurchaseOrder)
                .WithMany(po => po.Details)
                .HasForeignKey(d => d.PurchaseOrderId);

            // One-to-one or many-to-one: PurchaseOrder -> Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PurchaseOrder)
                .WithMany()
                .HasForeignKey(p => p.PurchaseOrderId);

            // One-to-one or many-to-one: PurchaseOrder -> Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.PurchaseOrder)
                .WithMany()
                .HasForeignKey(i => i.PurchaseOrderId);

            // Optional: decimal precision settings (if needed for compatibility)
            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(d => d.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Total)
                .HasPrecision(18, 2);
        }
    }


}

