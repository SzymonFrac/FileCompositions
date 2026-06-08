using FileCompositions.Core.Directory.Context.Implementations;
using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.ResourceSchema.Initializer;
using FileCompositions.Hosting.ResourceSchema.Initializer.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory.Implementations;

internal sealed class HostResourceSchemaDirectoryRegisterFactory : IHostResourceSchemaDirectoryRegisterFactory
{
    public HostResourceSchemaRegister CreateDirectory<TOwnership, TNecessity, TFileSystem>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem> descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TFileSystem : class, IFileSystem =>
            new((in services) => services
                .AddKeyedSingleton<IDirectoryDefinition<TOwnership, TNecessity>>(descriptor.Key, (sp, key) =>
                {
                    var backend = sp.GetRequiredService<TFileSystem>();

                    var directoryContext = new DirectoryContext(backend);
                    var directory = descriptor.Activate(directoryContext);

                    return directory;
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaDirectoryInitializer<TOwnership, TNecessity>(descriptor.Key)));
}
