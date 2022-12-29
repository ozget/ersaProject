
using ErsaProject.Application.Abstractions.Services;
using ErsaProject.Application.Repositories;
using ErsaProject.Domain.Entities.Identity;
using ErsaProject.Persistence.Contexts;
using ErsaProject.Persistence.Repositories;
using ErsaProject.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
          
            service.AddDbContext<ErsaContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            service.AddIdentity<AppUser, AppRole>(option =>
            {
                option.Password.RequiredLength = 3;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ErsaContext>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IInternalAuthentication, AuthService>();
            service.AddScoped<IRoleService,RoleService>();

            service.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            service.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            service.AddScoped<IMenuReadRepository, MenuReadRepository>();
            service.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            service.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();



        }
    }
}
