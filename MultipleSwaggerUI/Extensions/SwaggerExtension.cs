using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MultipleSwaggerUI;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerWithGrouping(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            SwaggerGroupAttribute.GetSwaggerGroups().ToList().ForEach(_ => c.SwaggerDoc(_.Name, new OpenApiInfo { Title = "Multiple Swagger UI Api", Version = _.Name }));
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerUIWithGrouping(this IApplicationBuilder builder)
    {
        builder.UseSwagger();

        return builder.UseSwaggerUI(x => SwaggerGroupAttribute.GetSwaggerGroups().ToList().ForEach(_ => x.SwaggerEndpoint($"/swagger/{_.Name}/swagger.json", _.Name)));
    }
}
