build:
	dotnet build DependencyInjection.sln

run-weather-consoleapp:
	dotnet run --project src/Weather.ConsoleApp/Weather.ConsoleApp.csproj