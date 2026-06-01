using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Descriptor.Abstract;

internal abstract class AbstractFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement>
        where TDefinition : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    protected string Name { get; } = name;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;
    public FileDefinitionKey Key { get; } = key;

    public abstract TDefinition Activate(in IFileContext context);
}
