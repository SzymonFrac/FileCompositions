using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Factory;

public interface IJsonDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    IJsonDefinitionBuilder<TInOwnership, TInNecessity, TData> Create<TData>();
    internal IJsonDefinitionBuilder<TOwnership, TNecessity, TData> Create<TOwnership, TNecessity, TData>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
