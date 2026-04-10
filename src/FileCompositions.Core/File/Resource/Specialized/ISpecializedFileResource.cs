using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Context;
using FileCompositions.Core.File.Resource.Specialized.StreamAccessor;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Specialized;

public interface ISpecializedFileResource : IFileResource, ISpeicalizedFileResourceStreamAccessor
{
    internal ISpecializedFileResourceContext Context { get; }
    new StorageResourceName Name { get; }
}
