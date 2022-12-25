using System.Reflection;

namespace MultipleSwaggerUI;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class SwaggerGroupAttribute : Attribute
{
    public SwaggerGroupAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;

    public static IEnumerable<SwaggerGroupAttribute> GetSwaggerGroups()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var swaggerGroupAttributeList = new List<SwaggerGroupAttribute>();

        foreach (var assembly in assemblies)
        {
            var assemblyTypes = assembly.GetTypes();

            var swaggerGroupType = assemblyTypes
                   .SelectMany(x => x.GetMethods().Cast<MemberInfo>().Append(x))
                   .SelectMany(x => x.GetCustomAttributes<SwaggerGroupAttribute>());

            swaggerGroupAttributeList.AddRange(swaggerGroupType);
        }

        return swaggerGroupAttributeList.Distinct();
    }
}