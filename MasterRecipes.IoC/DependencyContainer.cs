using MasterRecipes.Data.Repositorys;
using MasterRecipes.Domain.Interfaces;
using MasterRecipes.Domain.Models;
using MasterRecipes.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MasterRecipes.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<Context>(
                 o => o.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"))
                 );

            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(o => { o.Providers.Add<GzipCompressionProvider>(); });

            services.AddScoped<IReceitasRepository, ReceitasRepository>();

        }
    }
}