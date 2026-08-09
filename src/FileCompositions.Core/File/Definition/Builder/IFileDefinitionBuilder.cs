using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder;

public interface IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBuilder : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
{
    TBuilder WithKey(FileDefinitionKey key);

    // comment for now - make quality changes in interface as source of truth... (or maybe even in quality definitions...)
    //IFileDefinitionBuilder<ExternalDefinition, TNecessity> External() => Create<ExternalDefinition, TNecessity>();
    //IFileDefinitionBuilder<StrictDefinition, TNecessity> Strict() => Create<StrictDefinition, TNecessity>();
    //IFileDefinitionBuilder<TOwnership, RequiredDefinition> Required() => Create<TOwnership, RequiredDefinition>();
    //IFileDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => Create<TOwnership, OptionalDefinition>();
};
