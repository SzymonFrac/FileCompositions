using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder.Abstract;

internal abstract class FileDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    public DirectoryDefinitionKey DirectoryKey { get; }
    protected FileDefinitionKey Key { get; set; }
    protected string? Name { get; set; }

    internal FileDefinitionBuilder(DirectoryDefinitionKey directoryKey) => DirectoryKey = directoryKey;
    protected FileDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) =>
        (DirectoryKey, Key, Name) = (directoryKey, key, name);
}
