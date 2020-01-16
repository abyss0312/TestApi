using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Installers
{
    public class MVCInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "TestApi", Version = "v1" });
            });
        }
    }
}
