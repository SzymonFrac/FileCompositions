using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Builder;

public interface IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem>
    where TOwnership : Ownership
    where TNecessity : Necessity
    where TFileSystem : class, IFileSystem
{
    IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> WithKey(DirectoryDefinitionKey key);

    IDirectoryDefinitionBuilder<Ownership.External, TNecessity, TFileSystem> External();
    IDirectoryDefinitionBuilder<Ownership.Internal, TNecessity, TFileSystem> Strict();
    IDirectoryDefinitionBuilder<TOwnership, Necessity.Required, TFileSystem> Required();
    IDirectoryDefinitionBuilder<TOwnership, Necessity.Optional, TFileSystem> Optional();

    internal IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context);
    internal IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem> BuildDescriptor();
}
