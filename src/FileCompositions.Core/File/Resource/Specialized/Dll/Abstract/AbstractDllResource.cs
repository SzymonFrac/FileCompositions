using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Resource.Name;
using System.Reflection;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Abstract;

internal abstract class AbstractDllResource(IFileContext context, string name)
    : AbstractFileResource(context, FileSystemResourceName.CreateDll(name)), IDllResource
{
    public Assembly? Assembly { get; set; }
}
