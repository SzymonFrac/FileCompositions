using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.LocationResolver;

internal interface IFileLocationResolver
{
    IFileResource? Resolve(IDirectoryLocation directory, StorageResourceName file);
    TFile? Resolve<TFile>(IDirectoryLocation directory, StorageResourceName file)
        where TFile : IFileResource;
    IEnumerable<IFileResource> ResolveRange(IDirectoryLocation directory, IEnumerable<StorageResourceName> file);
}