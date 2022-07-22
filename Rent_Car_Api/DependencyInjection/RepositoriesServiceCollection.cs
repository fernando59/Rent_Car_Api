using Rent_Car_Api.Managers.Brand;

namespace Rent_Car_Api.DependencyInjection
{
    public static class RepositoriesServiceCollection
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IBrandManager, BrandManager>();

    }
}
