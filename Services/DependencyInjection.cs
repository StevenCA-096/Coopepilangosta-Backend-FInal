
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.IRepository;
using Services.Repository;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IProductProducerRepository, ProductProducerRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IProducerOrderRepository, ProducerOrderRepository > ();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStockReportRepository, StockReportRepository>();
            services.AddScoped<IForesightRepository, ForesightRepository>();
            services.AddScoped<IForesightProducerRepository, ForesightProducerRepository>();
            services.AddScoped<ICostumerRepository, CostumerRepository>();
            services.AddScoped<ICostumerOrderRepository, CostumerOrderRepository>();

            services.AddScoped<ICostumerContactRepository, CostumerContactRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IProductCostumerRepository, ProductCostumerRepository>();
            services.AddScoped<IVolumeDiscountRepository, VolumeDiscountRepository>();



            return services;
        }

    }
}
