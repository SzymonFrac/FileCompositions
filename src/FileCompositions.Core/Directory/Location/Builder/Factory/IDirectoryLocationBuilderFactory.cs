using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder.Factory;

internal interface IDirectoryLocationBuilderFactory
{
    IDirectoryLocationBuilder Create(IStorageBackend storageBackend, IFileLocationResolver resolver);
}
