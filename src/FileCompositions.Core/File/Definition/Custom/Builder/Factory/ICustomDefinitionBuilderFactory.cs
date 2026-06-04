using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Custom.Builder.Factory;

public interface ICustomDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    ICustomDefinitionBuilder<StrictDefinition, TInNecessity, TInNecessity> Create();
    internal ICustomDefinitionBuilder<TOwnership, TNecessity, TInNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
