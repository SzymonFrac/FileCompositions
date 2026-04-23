using FileCompositions.Core.File.Resource.Context;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource
{
    internal IFileResourceContext Context { get; }
    StorageResourceName Name { get; }
}