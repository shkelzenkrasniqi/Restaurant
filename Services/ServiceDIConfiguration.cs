using Microsoft.Extensions.DependencyInjection;
using Service.Abstractions;
using Microsoft.Extensions.Configuration;


namespace Services
{
    public class ServicesDIConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
        }
    }
}
