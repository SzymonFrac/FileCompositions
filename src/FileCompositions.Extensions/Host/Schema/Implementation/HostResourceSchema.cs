using FileCompositions.Extensions.Host.Schema.Directory.Registries;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Implementation;

internal class HostResourceSchema(IHostResourceSchemaDirectoryRegistries directoryRegisters) : IHostResourceSchema
{
    private readonly IHostResourceSchemaDirectoryRegistries _directoryRegisters = directoryRegisters;
    public IHostResourceSchema Init(ref IServiceCollection services)
    {
        _directoryRegisters.Register(ref services);

        return this;
    }
}
