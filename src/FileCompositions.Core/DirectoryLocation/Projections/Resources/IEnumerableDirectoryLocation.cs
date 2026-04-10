using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.File.Resource.Specialized.Query;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.Projections.Resources;

public interface IEnumerableDirectoryLocation
{
    internal ValueTask<TFile?> GetResource<TFile>(StorageResourceName name, CancellationToken cancellationToken = default)
        where TFile : ISpecializedFileResource;
    ISpecializedFileResourceQuery EnumerateResources(CancellationToken cancellationToken = default);
}
