using Microsoft.AspNetCore.Authentication;
using OrderApi.Application.Features.CQRS.Handler.AddressHandler;
using OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers;
using OrderApi.Application.Interfaces;
using OrderApi.Persistence.Repositories;
using OrderApi.Persistence.Services;
using OrderApi.WebUI.Auth;


namespace MultiShop.Order.WebApi.Controllers

{
    public static class ServiceExtension
    {
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
           services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddScoped<GetOrderDetailQueryHandler>();
           services.AddScoped<GetOrderDetailByIdQueryHandler>();
           services.AddScoped<CreateOrderDetailCommandHandler>();
           services.AddScoped<UpdateOrderDetailCommandHandler>();
           services.AddScoped<RemoveOrderDetailCommandHandler>();

           services.AddScoped<GetAddressQueryHandler>();
           services.AddScoped<GetAddressByIdQueryHandler>();
           services.AddScoped<CreateAddressCommandHandler>();
           services.AddScoped<UpdateAddressCommandHandler>();
           services.AddScoped<RemoveAddressCommandHandler>();
        }
        public static void AddBasicAuthentication(this IServiceCollection services) 
        {

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }
    }
}
