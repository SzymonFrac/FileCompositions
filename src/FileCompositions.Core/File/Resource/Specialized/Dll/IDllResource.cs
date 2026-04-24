using FileCompositions.Core.File.Resource.Specialized.Dll.Context;
using FileCompositions.Core.File.Resource.Specialized.Dll.Interface;

namespace FileCompositions.Core.File.Resource.Specialized.Dll;

public interface IDllResource : IFileResource, IDllResourceInterface
{
    new internal IDllResourceContext Context { get; }
}
