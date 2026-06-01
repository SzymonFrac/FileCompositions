using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Factory.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Extensions.Host.Schema.Initializer;
using FileCompositions.Extensions.Host.Schema.Initializer.Implementations;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Builder.Implementations;

internal class HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity> : IHostResourceSchemaFileRegisterBuilder
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    private readonly FileContextFactory _fileContextFactory = new();
    public HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement> =>
            new((in services) => services
                .AddKeyedSingleton<TDefinition>(descriptor.Key, (sp, key) =>
                {
                    var directory = sp.GetRequiredKeyedService<IDirectoryDefinition<TInOwnership, TInNecessity>>(descriptor.DirectoryKey);
                    var context = _fileContextFactory.Create(directory);

                    var file = descriptor.Activate(context);
                    return file;
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaFileInitializer<TDefinition, TOwnership, TPlacement>(descriptor.Key)));
}
