using FileCompositions.Core.File.Specialized.Dll.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Factory;

public interface IDllDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    IDllDefinitionBuilder<StrictDefinition, TInNecessity> Create();
    internal IDllDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
