using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.FileSystem.Source;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement> : IFileSystemSource
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    // Should move Context out as privat readonly _context;
    //internal IFileContext Context { get; }
    
    FileSystemResourceName Name { get; }

    FileSystemAddress RequestAddress();
    // move to context...
    // Requesting FileSystem is not (really) on file.
    // Then IContext could work on what lazy/eager or trigger happens - but that should come from file.
    //internal Task<IFileSystem> RequestFileSystemAsync(CancellationToken cancellationToken = default);
        //=>
        //Task.FromResult(Context.StorageBackend);
}
