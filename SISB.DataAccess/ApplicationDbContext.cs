using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SISB.Entities;

namespace SISB.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductBatch> ProductBatches { get; set; } = null!;
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<SaleItem> SaleItems { get; set; } = null!;
        public DbSet<StockMovement> StockMovements { get; set; } = null!;
        public DbSet<StockAdjustment> StockAdjustments { get; set; } = null!;
        public DbSet<Alert> Alerts { get; set; } = null!;
        public DbSet<ForecastResult> ForecastResults { get; set; } = null!;
        public DbSet<ReorderSuggestion> ReorderSuggestions { get; set; } = null!;
        public DbSet<AiChatLog> AiChatLogs { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;

        // Recommended workflow extensions.
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; } = null!;
        public DbSet<GoodsReceiptItem> GoodsReceiptItems { get; set; } = null!;
        public DbSet<SaleReturn> SaleReturns { get; set; } = null!;
        public DbSet<SaleReturnItem> SaleReturnItems { get; set; } = null!;
        public DbSet<SupplierPayment> SupplierPayments { get; set; } = null!;
        public DbSet<CustomerPayment> CustomerPayments { get; set; } = null!;
        public DbSet<StockCount> StockCounts { get; set; } = null!;
        public DbSet<StockCountItem> StockCountItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Identity and roles
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("AspNetUsers");
                entity.Property(u => u.FullName).HasMaxLength(150).IsRequired();
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "ROLE-OWNER", Name = "Owner", NormalizedName = "OWNER", ConcurrencyStamp = "ROLE-OWNER-SEED" },
                new IdentityRole { Id = "ROLE-MANAGER", Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = "ROLE-MANAGER-SEED" },
                new IdentityRole { Id = "ROLE-SALES-STAFF", Name = "Sales Staff", NormalizedName = "SALES STAFF", ConcurrencyStamp = "ROLE-SALES-STAFF-SEED" }
            );

            // 2. Categories, products, batches and suppliers
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Name);
                entity.HasOne(c => c.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(c => c.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(p => p.SKU).IsUnique();
                entity.HasIndex(p => p.Barcode).IsUnique().HasFilter("[Barcode] IS NOT NULL");
                entity.Property(p => p.PurchasePrice).HasColumnType("decimal(18, 2)");
                entity.Property(p => p.SellingPrice).HasColumnType("decimal(18, 2)");
                entity.Property(p => p.WAC).HasColumnType("decimal(18, 2)");
                entity.Property(p => p.ReorderLevel).HasColumnType("decimal(18, 3)");
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.PreferredSupplier)
                    .WithMany(s => s.PreferredProducts)
                    .HasForeignKey(p => p.PreferredSupplierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductBatch>(entity =>
            {
                entity.HasIndex(b => new { b.ProductId, b.BatchNo }).IsUnique();
                entity.Property(b => b.Quantity).HasColumnType("decimal(18, 3)");
                entity.HasOne(b => b.Product)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(b => b.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(s => s.Balance).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.CreditLimit).HasColumnType("decimal(18, 2)");
                entity.Property(c => c.DueBalance).HasColumnType("decimal(18, 2)");
            });

            // 3. Purchasing
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasIndex(po => po.PoNumber).IsUnique();
                entity.Property(po => po.TotalAmount).HasColumnType("decimal(18, 2)");
                entity.Property(po => po.Status).HasConversion(
                    value => value == PurchaseOrderStatus.PartiallyReceived ? "Partially Received" : value.ToString(),
                    value => value == "Partially Received" ? PurchaseOrderStatus.PartiallyReceived : Enum.Parse<PurchaseOrderStatus>(value));
                entity.HasOne(po => po.Supplier)
                    .WithMany(s => s.PurchaseOrders)
                    .HasForeignKey(po => po.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(po => po.CreatedByUser)
                    .WithMany(u => u.CreatedPurchaseOrders)
                    .HasForeignKey(po => po.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.Property(i => i.QtyOrdered).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.QtyReceived).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.UnitCost).HasColumnType("decimal(18, 2)");
                entity.HasOne(i => i.PurchaseOrder)
                    .WithMany(po => po.Items)
                    .HasForeignKey(i => i.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.Product)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // 4. Sales
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(s => s.InvoiceNo).IsUnique();
                entity.Property(s => s.Subtotal).HasColumnType("decimal(18, 2)");
                entity.Property(s => s.Discount).HasColumnType("decimal(18, 2)");
                entity.Property(s => s.Total).HasColumnType("decimal(18, 2)");
                entity.Property(s => s.PaidAmount).HasColumnType("decimal(18, 2)");
                entity.Property(s => s.PaymentMethod).HasConversion(
                    value => value == PaymentMethod.MobileBanking ? "Mobile Banking" : value.ToString(),
                    value => value == "Mobile Banking" ? PaymentMethod.MobileBanking : Enum.Parse<PaymentMethod>(value));
                entity.Property(s => s.Status).HasConversion(
                    value => value == SaleStatus.PartiallyReturned ? "Partially Returned" : value.ToString(),
                    value => value == "Partially Returned" ? SaleStatus.PartiallyReturned : Enum.Parse<SaleStatus>(value));
                entity.HasOne(s => s.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(s => s.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(s => s.CreatedByUser)
                    .WithMany(u => u.CreatedSales)
                    .HasForeignKey(s => s.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.Property(i => i.Quantity).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.UnitPrice).HasColumnType("decimal(18, 2)");
                entity.Property(i => i.UnitCost).HasColumnType("decimal(18, 2)");
                entity.Property(i => i.Discount).HasColumnType("decimal(18, 2)");
                entity.HasOne(i => i.Sale)
                    .WithMany(s => s.Items)
                    .HasForeignKey(i => i.SaleId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.Product)
                    .WithMany(p => p.SaleItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(i => i.ProductBatch)
                    .WithMany(b => b.SaleItems)
                    .HasForeignKey(i => i.ProductBatchId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // 5. Stock ledger and adjustments
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.Property(m => m.Type).HasConversion<string>();
                entity.Property(m => m.Quantity).HasColumnType("decimal(18, 3)");
                entity.HasOne(m => m.Product)
                    .WithMany(p => p.StockMovements)
                    .HasForeignKey(m => m.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(m => m.ProductBatch)
                    .WithMany(b => b.StockMovements)
                    .HasForeignKey(m => m.ProductBatchId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(m => m.CreatedByUser)
                    .WithMany(u => u.StockMovements)
                    .HasForeignKey(m => m.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StockAdjustment>(entity =>
            {
                entity.Property(a => a.Quantity).HasColumnType("decimal(18, 3)");
                entity.Property(a => a.Status).HasConversion<string>();
                entity.HasOne(a => a.Product)
                    .WithMany(p => p.StockAdjustments)
                    .HasForeignKey(a => a.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(a => a.ProductBatch)
                    .WithMany()
                    .HasForeignKey(a => a.ProductBatchId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.CreatedByUser)
                    .WithMany(u => u.CreatedStockAdjustments)
                    .HasForeignKey(a => a.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(a => a.ApprovedByUser)
                    .WithMany(u => u.ApprovedStockAdjustments)
                    .HasForeignKey(a => a.ApprovedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // 6. Alerts, forecasting and assistant/audit logs
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.Property(a => a.Type).HasConversion(
                    value => value == AlertType.LowStock ? "Low Stock"
                        : value == AlertType.OutOfStock ? "Out of Stock"
                        : value.ToString(),
                    value => value == "Low Stock" ? AlertType.LowStock
                        : value == "Out of Stock" ? AlertType.OutOfStock
                        : Enum.Parse<AlertType>(value));
                entity.HasOne(a => a.Product)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(a => a.ProductId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ForecastResult>(entity =>
            {
                entity.Property(f => f.PredictedQty).HasColumnType("decimal(18, 3)");
                entity.Property(f => f.LowerBound).HasColumnType("decimal(18, 3)");
                entity.Property(f => f.UpperBound).HasColumnType("decimal(18, 3)");
                entity.Property(f => f.Mae).HasColumnType("decimal(18, 4)");
                entity.Property(f => f.Mape).HasColumnType("decimal(18, 4)");
                entity.Property(f => f.Method).HasConversion<string>();
                entity.Property(f => f.Confidence).HasConversion<string>();
                entity.HasOne(f => f.Product)
                    .WithMany(p => p.ForecastResults)
                    .HasForeignKey(f => f.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ReorderSuggestion>(entity =>
            {
                entity.Property(r => r.SuggestedQty).HasColumnType("decimal(18, 3)");
                entity.Property(r => r.ROP).HasColumnType("decimal(18, 3)");
                entity.Property(r => r.DaysOfStockLeft).HasColumnType("decimal(18, 2)");
                entity.Property(r => r.Status).HasConversion<string>();
                entity.HasOne(r => r.Product)
                    .WithMany(p => p.ReorderSuggestions)
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Supplier)
                    .WithMany(s => s.ReorderSuggestions)
                    .HasForeignKey(r => r.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<AiChatLog>(entity =>
            {
                entity.HasOne(a => a.User)
                    .WithMany(u => u.AiChatLogs)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasOne(a => a.User)
                    .WithMany(u => u.AuditLogs)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. Goods receiving
            modelBuilder.Entity<GoodsReceipt>(entity =>
            {
                entity.HasIndex(g => g.GrnNumber).IsUnique();
                entity.HasOne(g => g.PurchaseOrder)
                    .WithMany(po => po.GoodsReceipts)
                    .HasForeignKey(g => g.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(g => g.ReceivedByUser)
                    .WithMany(u => u.GoodsReceipts)
                    .HasForeignKey(g => g.ReceivedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GoodsReceiptItem>(entity =>
            {
                entity.Property(i => i.QuantityReceived).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.UnitCost).HasColumnType("decimal(18, 2)");
                entity.HasIndex(i => new { i.GoodsReceiptId, i.PurchaseOrderItemId }).IsUnique();
                entity.HasOne(i => i.GoodsReceipt)
                    .WithMany(g => g.Items)
                    .HasForeignKey(i => i.GoodsReceiptId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.PurchaseOrderItem)
                    .WithMany(po => po.GoodsReceiptItems)
                    .HasForeignKey(i => i.PurchaseOrderItemId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(i => i.Product)
                    .WithMany(p => p.GoodsReceiptItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(i => i.ProductBatch)
                    .WithMany(b => b.GoodsReceiptItems)
                    .HasForeignKey(i => i.ProductBatchId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // 8. Sales returns and payments
            modelBuilder.Entity<SaleReturn>(entity =>
            {
                entity.HasIndex(r => r.ReturnNo).IsUnique();
                entity.Property(r => r.TotalAmount).HasColumnType("decimal(18, 2)");
                entity.HasOne(r => r.Sale)
                    .WithMany(s => s.Returns)
                    .HasForeignKey(r => r.SaleId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.ProcessedByUser)
                    .WithMany(u => u.SaleReturns)
                    .HasForeignKey(r => r.ProcessedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SaleReturnItem>(entity =>
            {
                entity.Property(i => i.Quantity).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.UnitPrice).HasColumnType("decimal(18, 2)");
                entity.Property(i => i.RefundAmount).HasColumnType("decimal(18, 2)");
                entity.HasOne(i => i.SaleReturn)
                    .WithMany(r => r.Items)
                    .HasForeignKey(i => i.SaleReturnId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.SaleItem)
                    .WithMany(si => si.ReturnItems)
                    .HasForeignKey(i => i.SaleItemId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(i => i.Product)
                    .WithMany(p => p.SaleReturnItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(i => i.ProductBatch)
                    .WithMany(b => b.SaleReturnItems)
                    .HasForeignKey(i => i.ProductBatchId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<SupplierPayment>(entity =>
            {
                entity.Property(p => p.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(p => p.PaymentMethod).HasConversion(
                    value => value == PaymentMethod.MobileBanking ? "Mobile Banking" : value.ToString(),
                    value => value == "Mobile Banking" ? PaymentMethod.MobileBanking : Enum.Parse<PaymentMethod>(value));
                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Payments)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.PurchaseOrder)
                    .WithMany(po => po.Payments)
                    .HasForeignKey(p => p.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.CreatedByUser)
                    .WithMany(u => u.SupplierPayments)
                    .HasForeignKey(p => p.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomerPayment>(entity =>
            {
                entity.Property(p => p.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(p => p.PaymentMethod).HasConversion(
                    value => value == PaymentMethod.MobileBanking ? "Mobile Banking" : value.ToString(),
                    value => value == "Mobile Banking" ? PaymentMethod.MobileBanking : Enum.Parse<PaymentMethod>(value));
                entity.HasOne(p => p.Customer)
                    .WithMany(c => c.Payments)
                    .HasForeignKey(p => p.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Sale)
                    .WithMany(s => s.Payments)
                    .HasForeignKey(p => p.SaleId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.ReceivedByUser)
                    .WithMany(u => u.CustomerPayments)
                    .HasForeignKey(p => p.ReceivedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // 9. Physical stock counts
            modelBuilder.Entity<StockCount>(entity =>
            {
                entity.HasIndex(c => c.CountNumber).IsUnique();
                entity.Property(c => c.Status).HasConversion<string>();
                entity.HasOne(c => c.StartedByUser)
                    .WithMany(u => u.StartedStockCounts)
                    .HasForeignKey(c => c.StartedBy)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(c => c.ApprovedByUser)
                    .WithMany(u => u.ApprovedStockCounts)
                    .HasForeignKey(c => c.ApprovedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<StockCountItem>(entity =>
            {
                entity.Property(i => i.SystemQuantity).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.CountedQuantity).HasColumnType("decimal(18, 3)");
                entity.Property(i => i.Variance)
                    .HasColumnType("decimal(18, 3)")
                    .HasComputedColumnSql("[CountedQuantity] - [SystemQuantity]", stored: true);
                entity.HasIndex(i => new { i.StockCountId, i.ProductId }).IsUnique();
                entity.HasOne(i => i.StockCount)
                    .WithMany(c => c.Items)
                    .HasForeignKey(i => i.StockCountId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.Product)
                    .WithMany(p => p.StockCountItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
