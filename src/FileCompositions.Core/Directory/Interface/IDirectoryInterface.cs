using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Interface;

public interface IDirectoryInterface<TNecessity>
    where TNecessity : DefinitionNecessity
{
    internal IStorageBackend StorageBackend { get; }

    StorageAddress Address { get; }
}
