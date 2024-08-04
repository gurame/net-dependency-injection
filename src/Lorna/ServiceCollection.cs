
namespace Lorna;

public class ServiceCollection : List<ServiceDescriptor>
{
	public ServiceCollection AddSingleton<TService, TImplementation>()
		where TService : class
		where TImplementation : class, TService
		{
			AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Singleton);
			return this;
		}

    public ServiceCollection AddTransient<TService, TImplementation>()
		where TService : class
		where TImplementation : class, TService
		{
			AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Transient);
			return this;
		}
	private void AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime lifetime)
        where TService : class
        where TImplementation : class, TService
    {
        var descriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementationType = typeof(TImplementation),
            Lifetime = lifetime
		};
        Add(descriptor);
    }

	public ServiceProvider BuildServiceProvider()
	{
		return new ServiceProvider(this);
	}
}
