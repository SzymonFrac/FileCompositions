using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Specialized.Dll.Definition.Extensions;
using FileCompositions.Core.FileSystem.Resource.Name;
using System.Reflection;

namespace FileCompositions.Core.File.Specialized.Dll.Resource.Abstract;

internal abstract class AbstractDllResource(IFileContext context, string name)
    : AbstractFileResource(context, FileSystemResourceName.CreateDll(name)), IDllResource
{
    public Assembly? Assembly { get; set; }
}
