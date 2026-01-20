using Microsoft.OpenApi;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.DataAccess.Repositories;
using System.Reflection;

namespace PromoCodeFactory.WebHost;

public static class DependencyInjection
{
    public static void AddOpenApi(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = $"PromoCodeFactory API ({env.EnvironmentName})"
            });
            s.SupportNonNullableReferenceTypes();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            s.IncludeXmlComments(xmlPath);
        });
    }

    public static void AddDataAccess(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IRepository<Employee>), (x) =>
            new InMemoryRepository<Employee>(FakeDataFactory.Employees));
        services.AddSingleton(typeof(IRepository<Role>), (x) =>
            new InMemoryRepository<Role>(FakeDataFactory.Roles));
    }
}
