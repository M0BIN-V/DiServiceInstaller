using Microsoft.Extensions.Hosting;

namespace DiServiceInstaller;

public interface IServiceInstaller
{
    void Install(IHostApplicationBuilder builder);
}