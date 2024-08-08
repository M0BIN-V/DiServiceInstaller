using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiServiceInstaller;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}