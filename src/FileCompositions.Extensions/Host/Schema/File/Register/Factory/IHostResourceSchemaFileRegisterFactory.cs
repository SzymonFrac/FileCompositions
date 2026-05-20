using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Factory;

internal interface IHostResourceSchemaFileRegisterFactory<TInOwnership, TInNecessity, TDirectory>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDirectory : IDirectoryDefinition<TInOwnership, TInNecessity>
{
    HostResourceSchemaRegister CreateFile<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement>;
}
