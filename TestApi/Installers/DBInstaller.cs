using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Services;
using TestApi.Services.Interfaces;

namespace TestApi.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IICustomers, CustomerServices>();
        }
    }
}
