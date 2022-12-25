using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace MultipleSwaggerUI;

public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ApiExplorer.GroupName = controller.ControllerType?.GetCustomAttribute<SwaggerGroupAttribute>()?.Name ?? string.Empty;
    }
}