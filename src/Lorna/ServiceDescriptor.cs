namespace Lorna;

public class ServiceDescriptor
{
	public Type ServiceType { get; set; }
	public Type ImplementationType { get; set; }
	public ServiceLifetime Lifetime { get; set; }
}
