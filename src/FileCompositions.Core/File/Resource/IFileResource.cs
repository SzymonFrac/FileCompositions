using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Interface;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource : IFileResourceInterface
{
    internal IFileContext Context { get; }

    StorageResourceName Name { get; }
}