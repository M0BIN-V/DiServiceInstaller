[![NuGet Package](https://img.shields.io/nuget/v/DiServiceInstaller)](https://www.nuget.org/packages/DiServiceInstaller/)
[![NuGet](https://img.shields.io/nuget/dt/DiServiceInstaller)](https://www.nuget.org/packages/DiServiceInstaller)

### Table of Contents

- [Installation](#installation)
- [Usage](#usage)


### Installation

To install `DiServiceInstaller`, use the following command in your terminal:

```bash
dotnet add package DiServiceInstaller
```

Ensure that you have the required .NET SDK installed.

---

### Usage

Program.cs

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.InstallServices();
```

### Installer 

```csharp
public class DbServiceInstaller : IServiceInstaller
{
    public void Install(IApplicatoinBuilder builder)
    {
        
        Builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(Builder.Configuration.GetConnectionString("Database"));
        });
    }
}
```

---