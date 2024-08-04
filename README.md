## Overview

This project demonstrates various implementations of dependency injection (DI) in .NET applications. It includes different application types, each showcasing unique DI techniques. The project also leverages the Scrutor library for implementing decorators and scanning, and features a custom DI implementation in the `Lorna` project.

## Project Structure

```
src/
	Consumer.ConsoleApp/
	CustomScope.ConsoleApp/
	Decorator.Api/
	Lorna/
	MultiFunction.ConsoleApp/
	Scanning.ConsoleApp/
	Weather.Api/
	Weather.ConsoleApp/
	Weather.WebApi/
	Weather.WebApp/
```

## Application Implementations

### Consumer.ConsoleApp

This console application demonstrates basic DI concepts using the built-in .NET DI container. It includes services like `ConsoleWriter` and `IdGenerator`.

### CustomScope.ConsoleApp

This console application showcases custom scoping of services. It includes an `ExampleService` that demonstrates how to manage service lifetimes manually.

### Decorator.Api

This API project demonstrates the use of decorators with the Scrutor library. It includes a [`WeatherService`] "src/Decorator.Api/Services/WeatherService.cs") that is decorated by a [`LoggerWeatherService`]"src/Decorator.Api/Services/LoggerWeatherService.cs") to add logging functionality.

### Scanning.ConsoleApp

This console application demonstrates the use of Scrutor for scanning and registering services automatically.

### Weather.Api, Weather.ConsoleApp, Weather.WebApi, Weather.WebApp

These projects demonstrate various DI techniques in different types of applications, including APIs, console apps, and web apps.

## Using Scrutor for Decorators and Scanning

### Decorators

In the `Decorator.Api` project, Scrutor is used to implement decorators. The [`WeatherService`] "src/Decorator.Api/Services/WeatherService.cs") is decorated by the [`LoggerWeatherService`] "src/Decorator.Api/Services/LoggerWeatherService.cs") to add logging functionality. This is achieved using the [`Decorate`] method provided by Scrutor.

```csharp
// src/Decorator.Api/Program.cs
builder.Services.Decorate<IWeatherService, LoggerWeatherService>();
```

### Scanning

In the `Scanning.ConsoleApp` project, Scrutor is used to scan and register services automatically. This reduces the need for manual service registration and ensures that all services are registered consistently.

```xml
<!-- src/Scanning.ConsoleApp/Scanning.ConsoleApp.csproj -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Scrutor" Version="4.2.2" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
  </ItemGroup>
</Project>
```

## Custom Dependency Injection Implementation: Lorna

The `Lorna` project features a custom DI implementation. It includes classes like [`ServiceDescriptor`] "src/Lorna/ServiceDescriptor.cs") and [`ServiceProvider`] "src/Lorna/ServiceProvider.cs") to manage service registrations and resolutions.

### ServiceDescriptor

The [`ServiceDescriptor`] "src/Lorna/ServiceDescriptor.cs") class represents a service registration, including the service type, implementation type, and lifetime.

```csharp
// src/Lorna/ServiceDescriptor.cs
namespace Lorna;
public class ServiceDescriptor
{
	public Type ServiceType { get; set; }
	public Type ImplementationType { get; set; }
	public ServiceLifetime Lifetime { get; set; }
}
```

### ServiceProvider

The `ServiceProvider` class is a custom implementation of the `IServiceProvider` interface, responsible for resolving services.

```csharp
// src/Lorna/ServiceProvider.cs
namespace Lorna;
public class ServiceProvider : IServiceProvider
{
	// Custom implementation details
}
```

### Upconming implementations
- Lamar
- SimplerInjector

## Conclusion

This project provides a comprehensive overview of various DI techniques in .NET applications, including the use of Scrutor for decorators and scanning, and a custom DI implementation in the `Lorna` project. Each application type demonstrates unique aspects of DI, making this project a valuable resource for learning and implementing DI in .NET.