using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace DiServiceInstaller;

public static class Extensions
{
    public static IHostApplicationBuilder InstallServices(
        this IHostApplicationBuilder applicationBuilder,
        params Assembly[] assemblies)
    {
        var installers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(a => a is { IsAbstract: false, IsInterface: false } && a
                .IsAssignableTo(typeof(IServiceInstaller)))
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (var installer in installers) installer.Install(applicationBuilder);

        return applicationBuilder;
    }
}