using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.LocationResolver;

internal interface IFileLocationResolver
{
    ISpecializedFileResource? Resolve(IDirectoryLocation directory, StorageResourceName file);
    TFile? Resolve<TFile>(IDirectoryLocation directory, StorageResourceName file)
        where TFile : ISpecializedFileResource;
    IEnumerable<ISpecializedFileResource> ResolveRange(IDirectoryLocation directory, IEnumerable<StorageResourceName> file);
}