using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Directory.Definition.Descriptor.Implementations;
using FileCompositions.Core.Directory.Definition.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Builder.Implementations;

internal sealed class DirectoryDefinitionBuilder<TOwnership, TNecessity, TSystem>
    : IDirectoryDefinitionBuilder<TOwnership, TNecessity, TSystem>
        where TOwnership : Ownership
        where TNecessity : Necessity
        where TSystem : class, IFileSystem
{
    private readonly FileSystemAddress address;
    private DirectoryDefinitionKey? key;

    internal DirectoryDefinitionBuilder(FileSystemAddress a) => address = a;
    private DirectoryDefinitionBuilder(DirectoryDefinitionKey? k, FileSystemAddress a) =>
        (key, address) = (k, a);

    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TSystem> WithKey(DirectoryDefinitionKey k)
    {
        key = k;
        return this;
    }

    public IDirectoryDefinitionBuilder<Ownership.External, TNecessity, TSystem> External() =>
        new DirectoryDefinitionBuilder<Ownership.External, TNecessity, TSystem>(key, address);
    public IDirectoryDefinitionBuilder<Ownership.Internal, TNecessity, TSystem> Strict() =>
        new DirectoryDefinitionBuilder<Ownership.Internal, TNecessity, TSystem>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, Necessity.Required, TSystem> Required() =>
        new DirectoryDefinitionBuilder<TOwnership, Necessity.Required, TSystem>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, Necessity.Optional, TSystem> Optional() =>
        new DirectoryDefinitionBuilder<TOwnership, Necessity.Optional, TSystem>(key, address);

    public IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context) =>
        key is not null
            ? new DirectoryDefinition<TOwnership, TNecessity>(context, key, address)
            : throw new NullReferenceException("Directory must have a key.");
    public IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TSystem> BuildDescriptor() =>
        key is not null
            ? new DirectoryDefinitionDescriptor<TOwnership, TNecessity, TSystem>(key, address)
            : throw new NullReferenceException("Directory must have a key.");
}
