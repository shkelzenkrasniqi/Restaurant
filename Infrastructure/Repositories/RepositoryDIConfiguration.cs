using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class RepositoryDIConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            //services.AddScoped<IGenericRepository<Restaurant>, GenericRepository<Restaurant>>();
           // services.AddScoped<IGenericRepository<FoodItem>, GenericRepository<FoodItem>>();
        }
    }
}
