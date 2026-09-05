using FileCompositions.Core.FileSystem.Definition.Key;

namespace FileCompositions.Core.FileSystem.Definition;

public interface IFileSystemDefinition
{
    FileSystemDefinitionKey Key { get; }
}
