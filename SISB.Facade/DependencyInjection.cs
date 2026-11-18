
using SISB.DataAccess;
using SISB.DataAccess.Interface;
using SISB.DataAccess.Implementation;
using SISB.Facade.Interface;
using SISB.Facade.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SISB.Facade
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSmartStockFacade(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryFacade, CategoryFacade>();

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductFacade, ProductFacade>();

            // Product Batch
            services.AddScoped<IProductBatchRepository, ProductBatchRepository>();
            services.AddScoped<IProductBatchFacade, ProductBatchFacade>();

            // Supplier
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierFacade, SupplierFacade>();

            // Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerFacade, CustomerFacade>();

            // Purchase Order
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderFacade, PurchaseOrderFacade>();

            services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
            services.AddScoped<IPurchaseOrderItemFacade, PurchaseOrderItemFacade>();

            // Goods Receipt
            services.AddScoped<IGoodsReceiptRepository, GoodsReceiptRepository>();
            services.AddScoped<IGoodsReceiptFacade, GoodsReceiptFacade>();

            services.AddScoped<IGoodsReceiptItemRepository, GoodsReceiptItemRepository>();
            services.AddScoped<IGoodsReceiptItemFacade, GoodsReceiptItemFacade>();

            // Sale
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleFacade, SaleFacade>();

            services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            services.AddScoped<ISaleItemFacade, SaleItemFacade>();

            // Sale Return
            services.AddScoped<ISaleReturnRepository, SaleReturnRepository>();
            services.AddScoped<ISaleReturnFacade, SaleReturnFacade>();

            services.AddScoped<ISaleReturnItemRepository, SaleReturnItemRepository>();
            services.AddScoped<ISaleReturnItemFacade, SaleReturnItemFacade>();

            // Payments
            services.AddScoped<ISupplierPaymentRepository, SupplierPaymentRepository>();
            services.AddScoped<ISupplierPaymentFacade, SupplierPaymentFacade>();

            services.AddScoped<ICustomerPaymentRepository, CustomerPaymentRepository>();
            services.AddScoped<ICustomerPaymentFacade, CustomerPaymentFacade>();

            // Stock
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IStockMovementFacade, StockMovementFacade>();

            services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();
            services.AddScoped<IStockAdjustmentFacade, StockAdjustmentFacade>();

            services.AddScoped<IStockCountRepository, StockCountRepository>();
            services.AddScoped<IStockCountFacade, StockCountFacade>();

            services.AddScoped<IStockCountItemRepository, StockCountItemRepository>();
            services.AddScoped<IStockCountItemFacade, StockCountItemFacade>();

            // Alerts
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IAlertFacade, AlertFacade>();

            // AI Forecasting
            services.AddScoped<IForecastResultRepository, ForecastResultRepository>();
            services.AddScoped<IForecastResultFacade, ForecastResultFacade>();

            services.AddScoped<IReorderSuggestionRepository, ReorderSuggestionRepository>();
            services.AddScoped<IReorderSuggestionFacade, ReorderSuggestionFacade>();

            services.AddScoped<IAiChatLogRepository, AiChatLogRepository>();
            services.AddScoped<IAiChatLogFacade, AiChatLogFacade>();

            // Audit Log
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IAuditLogFacade, AuditLogFacade>();

            // Application User
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationUserFacade, ApplicationUserFacade>();

            return services;
        }
    }
}
