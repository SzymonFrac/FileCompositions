using FileCompositions.Hosting.ResourceSchema.Initializer.Service.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Implementation;

internal sealed class HostResourceSchema(HostResourceSchemaRegister? register) : IHostResourceSchema
{
    private readonly HostResourceSchemaRegister? _register = register;
    public IHostResourceSchema Init(in IServiceCollection services)
    {
        _register?.Invoke(in services);

        services.AddHostedService<HostResourceSchemaInitializationService>();

        return this;
    }
}
