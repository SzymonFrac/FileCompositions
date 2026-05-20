using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Factory.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Factory.Implementations;

internal class HostResourceSchemaFileRegisterFactory<TInOwnership, TInNecessity, TDirectory> : IHostResourceSchemaFileRegisterFactory<TInOwnership, TInNecessity, TDirectory>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDirectory : IDirectoryDefinition<TInOwnership, TInNecessity>
{
    private readonly FileContextFactory _fileContextFactory = new();
    public HostResourceSchemaRegister CreateFile<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement> =>
            new((in services) =>
            {
                services.AddKeyedSingleton<TDefinition>(descriptor.Key, (sp, key) =>
                {
                    var directory = sp.GetRequiredKeyedService<TDirectory>(descriptor.DirectoryKey);
                    var context = _fileContextFactory.Create(directory);

                    var file = descriptor.Activate(context);
                    return file;
                });
            });
}
