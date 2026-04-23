using FileCompositions.Core.Directory.Context.Implementations;
using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Directory.Register.Factory.Implementations;

internal class HostResourceSchemaDirectoryRegisterFactory : IHostResourceSchemaDirectoryRegisterFactory
{
    public HostResourceSchemaDirectoryRegister Create<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend =>
            new ((ref services) =>
                services.AddKeyedSingleton<IDirectoryDefinition<TOwnership, TNecessity>>(descriptor.Key, (sp, key) =>
                {
                    var fileLocationResolver = sp.GetRequiredService<IFileLocationResolver>();
                    var backend = sp.GetRequiredService<TBackend>();

                    var directoryContext = new DirectoryContext(backend, fileLocationResolver);
                    var directory = descriptor.Activate(directoryContext);

                    return directory;
                }));
}
