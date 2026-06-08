using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Init;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition.Abstract;

internal abstract class AbstractDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, FileSystemAddress address)
    : IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public IDirectoryContext Context { get; } = context;

    public DirectoryDefinitionKey Key { get; } = key;
    public FileSystemAddress Address { get; } = address;

    IFileSystem IDirectoryInterface<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IFileSystem IDirectoryDefinitionInit<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IFileSystem IDirectoryOperator<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
}
