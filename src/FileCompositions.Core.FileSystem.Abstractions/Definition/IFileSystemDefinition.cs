using FileCompositions.Core.FileSystem.Abstractions.Definition.Key;

namespace FileCompositions.Core.FileSystem.Abstractions.Definition;

public interface IFileSystemDefinition
{
    FileSystemDefinitionKey Key { get; }
}
