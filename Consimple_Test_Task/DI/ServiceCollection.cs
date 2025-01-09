using Consimple_Test_Task.Core;
using Consimple_Test_Task.Core.Interfaces;
using Consimple_Test_Task.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Consimple_Test_Task.Api.DI;

public static class ServiceCollection
{
    public static void AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(connectionString, b=> b.MigrationsAssembly("Consimple_Test_Task.Api")));

        services.AddScoped<IStoreService, StoreService>();
    }
}