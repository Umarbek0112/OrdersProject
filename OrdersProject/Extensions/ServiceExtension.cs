using OrdersProject.Data.IRepository;
using OrdersProject.Data.Repository;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.IServices;
using OrdersProject.Service.Services;

namespace OrdersProject.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomerService(this IServiceCollection services)
        {

            services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
            services.AddScoped<IGenericRepository<UserOrder>, GenericRepository<UserOrder>>();


            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserOrderService, UserOrderService>();
        }
    }
}
