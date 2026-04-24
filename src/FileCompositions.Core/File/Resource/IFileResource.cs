using FileCompositions.Core.File.Context;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource
{
    internal IFileContext Context { get; }
    StorageResourceName Name { get; }
}