using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Query;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.Projections.Resources;

public interface IEnumerableDirectory
{
    internal ValueTask<TFile?> GetResource<TFile>(StorageResourceName name, CancellationToken cancellationToken = default)
        where TFile : IFileResource;
    IFileResourceQuery EnumerateResources(CancellationToken cancellationToken = default);
}
