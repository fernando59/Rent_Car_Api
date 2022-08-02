using Rent_Car_Api.Helpers.CloudinaryHelper;
using Rent_Car_Api.Managers.BrandM;
using Rent_Car_Api.Managers.ModelM;
using Rent_Car_Api.Managers.OrderM;
using Rent_Car_Api.Managers.PhotoM;
using Rent_Car_Api.Managers.TypeVehicleM;
using Rent_Car_Api.Managers.VehicleM;

namespace Rent_Car_Api.DependencyInjection
{
    public static class RepositoriesServiceCollection
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>services
            //Helpers
            .AddScoped<IImageCloudinary,ImageCloudinary>()
            //Managers
            .AddScoped<IBrandManager, BrandManager>()
            .AddScoped<IModelVehicleManager,ModelVehicleManager>()
            .AddScoped<ITypeVehicleManager,TypeVehicleManager>()
            .AddScoped<IPhotoManager,PhotoManager>()
            .AddScoped<IOrderManager,OrderManager>()
            .AddScoped<IVehicleManager,VehicleManager>();


    }
}
