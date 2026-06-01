using FileCompositions.Extensions.Host.Schema.Initializer.Service.Implementations;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Implementation;

internal class HostResourceSchema(HostResourceSchemaRegister? register) : IHostResourceSchema
{
    private readonly HostResourceSchemaRegister? _register = register;
    public IHostResourceSchema Init(in IServiceCollection services)
    {
        _register?.Invoke(in services);

        services.AddHostedService<HostResourceSchemaInitializationService>();

        return this;
    }
}
