using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Descriptor;

internal interface IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem>
    where TOwnership : Ownership
    where TNecessity : Necessity
    where TFileSystem : class, IFileSystem
{
    DirectoryDefinitionKey Key { get; }
    
    IDirectoryDefinition<TOwnership, TNecessity> Activate(in IDirectoryContext context);
}
