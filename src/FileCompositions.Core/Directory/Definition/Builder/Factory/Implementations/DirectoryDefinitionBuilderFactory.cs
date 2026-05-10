using FileCompositions.Core.Directory.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;

internal class DirectoryDefinitionBuilderFactory : IDirectoryDefinitionBuilderFactory
{
    public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition> CreateDefault() =>
        new DirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition>();
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DirectoryDefinitionBuilder<TOwnership, TNecessity>();
}
