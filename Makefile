build:
	dotnet build DependencyInjection.sln

run-weather-consoleapp:
	dotnet run --project src/Weather.ConsoleApp/Weather.ConsoleApp.csproj

run-customscope-consoleapp:
	dotnet run --project src/CustomScope.ConsoleApp/CustomScope.ConsoleApp.csproj

run-multifunction-consoleapp:
	dotnet run --project src/MultiFunction.ConsoleApp/MultiFunction.ConsoleApp.csproj

run-weather-api:
	dotnet run --project src/Weather.Api/Weather.Api.csproj

run-weather-webapi:
	dotnet run --project src/Weather.WebApi/Weather.WebApi.csproj

run-weather-webapp:
	dotnet run --project src/Weather.WebApp/Weather.WebApp.csproj