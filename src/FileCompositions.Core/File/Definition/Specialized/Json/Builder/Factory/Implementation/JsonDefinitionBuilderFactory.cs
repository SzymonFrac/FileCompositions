using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Factory.Implementation;

internal class JsonDefinitionBuilderFactory<TInOwnership, TInNecessity>(DirectoryDefinitionKey key) : IJsonDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    private readonly DirectoryDefinitionKey _key = key;

    public IJsonDefinitionBuilder<TInOwnership, TInNecessity, TData> Create<TData>() =>
        new JsonDefinitionBuilder<TInOwnership, TInNecessity, TData>(_key);
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> Create<TOwnership, TNecessity, TData>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new JsonDefinitionBuilder<TOwnership, TNecessity, TData>(_key);
}
