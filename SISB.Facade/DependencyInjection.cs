using SISB.DataAccess;
using SISB.DataAccess.Interface;
using SISB.Facade.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SISB.DataAccess.Implementation;
using SISB.Facade.Implementation;

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

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryFacade, CategoryFacade>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductFacade, ProductFacade>();

            services.AddScoped<IProductBatchRepository, ProductBatchRepository>();
            services.AddScoped<IProductBatchFacade, ProductBatchFacade>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierFacade, SupplierFacade>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerFacade, CustomerFacade>();

            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderFacade, PurchaseOrderFacade>();

            services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
            services.AddScoped<IPurchaseOrderItemFacade, PurchaseOrderItemFacade>();

            services.AddScoped<IGoodsReceiptRepository, GoodsReceiptRepository>();
            services.AddScoped<IGoodsReceiptFacade, GoodsReceiptFacade>();

            services.AddScoped<IGoodsReceiptItemRepository, GoodsReceiptItemRepository>();
            services.AddScoped<IGoodsReceiptItemFacade, GoodsReceiptItemFacade>();

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleFacade, SaleFacade>();

            services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            services.AddScoped<ISaleItemFacade, SaleItemFacade>();

            services.AddScoped<ISaleReturnRepository, SaleReturnRepository>();
            services.AddScoped<ISaleReturnFacade, SaleReturnFacade>();

            services.AddScoped<ISaleReturnItemRepository, SaleReturnItemRepository>();
            services.AddScoped<ISaleReturnItemFacade, SaleReturnItemFacade>();

            services.AddScoped<ISupplierPaymentRepository, SupplierPaymentRepository>();
            services.AddScoped<ISupplierPaymentFacade, SupplierPaymentFacade>();

            services.AddScoped<ICustomerPaymentRepository, CustomerPaymentRepository>();
            services.AddScoped<ICustomerPaymentFacade, CustomerPaymentFacade>();

            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IStockMovementFacade, StockMovementFacade>();

            services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();
            services.AddScoped<IStockAdjustmentFacade, StockAdjustmentFacade>();

            services.AddScoped<IStockCountRepository, StockCountRepository>();
            services.AddScoped<IStockCountFacade, StockCountFacade>();

            services.AddScoped<IStockCountItemRepository, StockCountItemRepository>();
            services.AddScoped<IStockCountItemFacade, StockCountItemFacade>();

            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IAlertFacade, AlertFacade>();

            services.AddScoped<IForecastResultRepository, ForecastResultRepository>();
            services.AddScoped<IForecastResultFacade, ForecastResultFacade>();

            services.AddScoped<IReorderSuggestionRepository, ReorderSuggestionRepository>();
            services.AddScoped<IReorderSuggestionFacade, ReorderSuggestionFacade>();

            services.AddScoped<IAiChatLogRepository, AiChatLogRepository>();
            services.AddScoped<IAiChatLogFacade, AiChatLogFacade>();

            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IAuditLogFacade, AuditLogFacade>();

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationUserFacade, ApplicationUserFacade>();

            return services;
        }
    }
}
