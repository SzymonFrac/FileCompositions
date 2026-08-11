using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder.Abstract;

public abstract class AbstractFileDefinitionBuilder<TOwnership, TNecessity, TBuilder> : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBuilder : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
{
    protected FileDefinitionKey? Key { get; set; }

    protected AbstractFileDefinitionBuilder() { }
    protected AbstractFileDefinitionBuilder(FileDefinitionKey? key = default) => Key = key;

    protected FileDefinitionKey BuildKey() => Key ?? throw new NullReferenceException("File definition must have a key.");

    public abstract TBuilder WithKey(FileDefinitionKey key);
}
