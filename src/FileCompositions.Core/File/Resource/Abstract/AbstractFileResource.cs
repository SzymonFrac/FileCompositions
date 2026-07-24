using FileCompositions.Core.File.Context;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, FileSystemResourceName name) : IFileResource
{
    public IFileContext Context { get; } = context;
    public FileSystemResourceName Name { get; } = name;
}
