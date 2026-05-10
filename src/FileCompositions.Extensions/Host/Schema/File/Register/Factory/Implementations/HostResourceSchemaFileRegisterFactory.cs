using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Factory.Implementations;

internal class HostResourceSchemaFileRegisterFactory<TDirectory> : IHostResourceSchemaFileRegisterFactory<TDirectory>
    where TDirectory : IDirectoryLocation
{
    public HostResourceSchemaRegister CreateFile<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity> =>
            new((in services) =>
            {
                services.AddKeyedSingleton<TDefinition>(descriptor.Key, (sp, key) =>
                {
                    var directory = sp.GetRequiredKeyedService<TDirectory>(descriptor.DirectoryKey);
                    var context = new FileContext(directory);

                    var file = descriptor.Activate(context);
                    return file;
                });
            });
}
