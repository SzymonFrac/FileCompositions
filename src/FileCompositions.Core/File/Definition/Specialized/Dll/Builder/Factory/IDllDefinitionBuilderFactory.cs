using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Factory;

public interface IDllDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    IDllDefinitionBuilder<StrictDefinition, TInNecessity> Create();
    internal IDllDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
