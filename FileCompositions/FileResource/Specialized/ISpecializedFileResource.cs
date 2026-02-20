using FileCompositions.Core.FileResource.Specialized.Context;
using FileCompositions.Core.FileResource.Specialized.StreamAccessor;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized;

public interface ISpecializedFileResource : IFileResource, ISpeicalizedFileResourceStreamAccessor
{
    internal ISpecializedFileResourceContext Context { get; }
    new StorageResourceName Name { get; }
}
