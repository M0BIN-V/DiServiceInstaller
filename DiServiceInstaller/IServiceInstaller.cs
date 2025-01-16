using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiServiceInstaller;

public interface IServiceInstaller
{
    void Install(IApplicationBuilder builder);
}