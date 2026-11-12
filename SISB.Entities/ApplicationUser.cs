using Microsoft.AspNetCore.Identity;

namespace SISB.Entities
{
    // ASP.NET Core Identity user. Owner, Manager and Sales Staff are Identity roles.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<PurchaseOrder> CreatedPurchaseOrders { get; set; } = new List<PurchaseOrder>();
        public virtual ICollection<Sale> CreatedSales { get; set; } = new List<Sale>();
        public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
        public virtual ICollection<StockAdjustment> CreatedStockAdjustments { get; set; } = new List<StockAdjustment>();
        public virtual ICollection<StockAdjustment> ApprovedStockAdjustments { get; set; } = new List<StockAdjustment>();
        public virtual ICollection<AiChatLog> AiChatLogs { get; set; } = new List<AiChatLog>();
        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; } = new List<GoodsReceipt>();
        public virtual ICollection<SaleReturn> SaleReturns { get; set; } = new List<SaleReturn>();
        public virtual ICollection<SupplierPayment> SupplierPayments { get; set; } = new List<SupplierPayment>();
        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();
        public virtual ICollection<StockCount> StartedStockCounts { get; set; } = new List<StockCount>();
        public virtual ICollection<StockCount> ApprovedStockCounts { get; set; } = new List<StockCount>();
    }
}
