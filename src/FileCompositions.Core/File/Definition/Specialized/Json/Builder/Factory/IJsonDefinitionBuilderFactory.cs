using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Factory;

public interface IJsonDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    IJsonDefinitionBuilder<StrictDefinition, TInNecessity, TData> Create<TData>();
    internal IJsonDefinitionBuilder<TOwnership, TNecessity, TData> Create<TOwnership, TNecessity, TData>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
