using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using DependencyStore.Services.Constracts;
using DependencyStore.Services;
using System.Data.SqlClient;

namespace DependencyStore.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectionString) 
            => services.AddScoped(con => new SqlConnection(connectionString));

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeesService, DeliveryFeeService>();
        }
    }
}
