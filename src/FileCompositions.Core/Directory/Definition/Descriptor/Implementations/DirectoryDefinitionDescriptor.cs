using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Descriptor.Implementations;

internal sealed class DirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem>(DirectoryDefinitionKey key, FileSystemAddress address)
    : IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem>
        where TOwnership : Ownership
        where TNecessity : Necessity
        where TFileSystem : class, IFileSystem
{
    private readonly FileSystemAddress _address = address;
    public DirectoryDefinitionKey Key { get; private set; } = key;
    
    public IDirectoryDefinition<TOwnership, TNecessity> Activate(in IDirectoryContext context) =>
        new DirectoryDefinition<TOwnership, TNecessity>(context, Key, _address);

}