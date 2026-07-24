using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Factory.Implementation;

internal sealed class JsonDefinitionBuilderFactory<TInNecessity>(DirectoryDefinitionKey key) : IJsonDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    private readonly DirectoryDefinitionKey _key = key;

    public IJsonDefinitionBuilder<StrictDefinition, TInNecessity, TData> Create<TData>() =>
        new JsonDefinitionBuilder<StrictDefinition, TInNecessity, TData>(_key);
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> Create<TOwnership, TNecessity, TData>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new JsonDefinitionBuilder<TOwnership, TNecessity, TData>(_key);
}
