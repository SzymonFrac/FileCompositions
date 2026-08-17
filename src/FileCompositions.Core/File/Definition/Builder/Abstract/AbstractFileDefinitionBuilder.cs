using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder.Abstract;

// no base abstract?
//internal abstract partial class AbstractFileDefinitionBuilder<TOwnership, TPlacement> : IFileDefinitionBuilder<TOwnership, TPlacement, TDefinition, TBuilder>
//    where TOwnership : DefinitionOwnership
//    where TPlacement : DefinitionPlacement
//{
//    protected FileDefinitionKey? Key { get; set; }

//    protected AbstractFileDefinitionBuilder() { }
//    protected AbstractFileDefinitionBuilder(FileDefinitionKey? key = default) => Key = key;

//    protected FileDefinitionKey BuildKey() => Key ?? throw new NullReferenceException("File definition must have a key.");

//    public abstract TBuilder WithKey(FileDefinitionKey key);
//}
