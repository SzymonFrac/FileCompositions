using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class FileResource(IFileContext context, StorageResourceName name) : IFileResource
{
    public IFileContext Context { get; } = context;
    public StorageResourceName Name { get; } = name;

    IStorageBackend IFileInterface<RequiredInRequired>.StorageBackend => Context.StorageBackend;
    StorageLocation IFileInterface<RequiredInRequired>.Location => Context.Address.With(Name);
}
