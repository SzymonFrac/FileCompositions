using FileCompositions.Extensions.Host.Schema.Directory.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Directory.Registries;

internal interface IHostResourceSchemaDirectoryRegistries : IEnumerable<HostResourceSchemaDirectoryRegister>
{
    void Register(ref IServiceCollection services);
}
