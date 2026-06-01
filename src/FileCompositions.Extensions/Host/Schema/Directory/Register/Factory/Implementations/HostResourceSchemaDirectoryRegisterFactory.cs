using FileCompositions.Core.Directory.Context.Implementations;
using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Initializer;
using FileCompositions.Extensions.Host.Schema.Initializer.Implementations;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Directory.Register.Factory.Implementations;

internal class HostResourceSchemaDirectoryRegisterFactory : IHostResourceSchemaDirectoryRegisterFactory
{
    public HostResourceSchemaRegister CreateDirectory<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend =>
            new((in services) => services
                .AddKeyedSingleton<IDirectoryDefinition<TOwnership, TNecessity>>(descriptor.Key, (sp, key) =>
                {
                    var backend = sp.GetRequiredService<TBackend>();

                    var directoryContext = new DirectoryContext(backend);
                    var directory = descriptor.Activate(directoryContext);

                    return directory;
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaDirectoryInitializer<TOwnership, TNecessity>(descriptor.Key)));
}
