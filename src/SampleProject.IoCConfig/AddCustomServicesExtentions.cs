using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SampleProject.DataLayer.Context;
using SampleProject.Services.Contracts;
using SampleProject.Services.Contracts.EFServices;
using SampleProject.ViewModels.App;

namespace SampleProject.IoCConfig;
public static class AddCustomServicesExtentions
{
    public static IServiceCollection AddCustomeServices(this IServiceCollection services)
    {
        var provider=services.BuildServiceProvider();
        var connectionStrings = provider.GetRequiredService<IOptionsMonitor< ConnectionStrings >> ().CurrentValue;
        services.AddDbContext<SampleProjectDbContext>(options=>{
            options.UseSqlServer(connectionStrings.SampleProjectDbCotextConnection);
        });

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
       
}
