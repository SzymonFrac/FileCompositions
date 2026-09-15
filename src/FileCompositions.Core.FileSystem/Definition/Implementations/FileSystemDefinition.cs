using FileCompositions.Core.FileSystem.Abstractions.Definition;
using FileCompositions.Core.FileSystem.Abstractions.Definition.Key;

namespace FileCompositions.Core.FileSystem.Definition.Implementations;

internal sealed class FileSystemDefinition(IFileSystem fileSystem, FileSystemDefinitionKey key) : IFileSystemDefinition
{
    private readonly IFileSystem _fileSystem = fileSystem;
    
    public FileSystemDefinitionKey Key { get; } = key;
}
