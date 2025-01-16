using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace DiServiceInstaller;

public static class DependencyInjection
{
    public static IApplicationBuilder InstallServices(
        this IApplicationBuilder applicationBuilder,
        params Assembly[] assemblies)
    {
        var installers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(a => !a.IsAbstract && !a.IsInterface && a
                .IsAssignableTo(typeof(IServiceInstaller)))
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (var installer in installers)
        {
            installer.Install(applicationBuilder);
        }

        return applicationBuilder;
    }
}