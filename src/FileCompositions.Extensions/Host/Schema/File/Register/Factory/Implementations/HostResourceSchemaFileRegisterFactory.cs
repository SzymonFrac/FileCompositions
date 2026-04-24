using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Factory.Implementations;

internal class HostResourceSchemaFileRegisterFactory : IHostResourceSchemaFileRegisterFactory
{
    public HostResourceSchemaFileRegister Create<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity> =>
            new((in services) =>
            {
                services.AddKeyedSingleton<TDefinition>(descriptor.Key, (sp, key) =>
                {
                    // use location instead of definition to make the fileContext -
                    // but registered DirDefinition may not implicitly register the inherited, so could be a bug...
                    var directory = sp.GetRequiredKeyedService<IDirectoryLocation>(descriptor.DirectoryKey);
                    var context = new FileContext(directory);

                    var file = descriptor.Activate(context);
                    return file;
                });
            });
}
