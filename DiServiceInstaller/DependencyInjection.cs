using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DiServiceInstaller;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        var installers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(a => !a.IsAbstract && !a.IsInterface && a
                .IsAssignableFrom(typeof(IServiceInstaller)))
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (var installer in installers)
        {
            installer.Install(services, configuration);
        }

        return services;
    }
}