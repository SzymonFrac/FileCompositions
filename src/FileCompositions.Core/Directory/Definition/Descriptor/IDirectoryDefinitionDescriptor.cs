using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition.Descriptor;

internal interface IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TFileSystem : class, IFileSystem
{
    DirectoryDefinitionKey Key { get; }
    
    IDirectoryDefinition<TOwnership, TNecessity> Activate(in IDirectoryContext context);
}
