using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Builder.Abstract;


// Instead of an Abstract builder, there will be sealed interface members for qualites + key.
// Then extensions will propergate them to TBuilder.
public abstract class AbstractFileDefinitionBuilder<TOwnership, TNecessity, TBuilder> : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBuilder : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
{
    protected FileDefinitionKey? Key { get; set; }

    protected AbstractFileDefinitionBuilder() { }
    protected AbstractFileDefinitionBuilder(FileDefinitionKey? key) => Key = key;

    protected abstract TBuilder Create<TNewOwnership, TNewNecessity>();

    public abstract TBuilder WithKey(FileDefinitionKey key);

    //public TBuilder External() => Create<ExternalDefinition, TNecessity>();
    //public TBuilder Strict() => Create<StrictDefinition, TNecessity>();
    //public TBuilder Required() => Create<TOwnership, RequiredDefinition>();
    //public TBuilder Optional() => Create<TOwnership, OptionalDefinition>();
}
