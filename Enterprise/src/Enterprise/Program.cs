using System.Threading.Tasks;
using Enterprise.Models;
using Enterprise.Repository.Context;
using Enterprise.Repository.Interfaces;
using Enterprise.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repository = Enterprise.Repository.Repositories;

namespace Enterprise
{
    public static class Program
    {
        public static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<Startup>()
                .AddTransient<Context>()
                .AddTransient<IRepository<ConfigEntity>, Repository<ConfigEntity>>()
                .BuildServiceProvider();

            var startup = serviceProvider.GetService<Startup>();
            await startup.Run();
        }
    }
}