using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Specialized.Dll.Name.Ext;
using FileCompositions.Core.FileSystem.Addressing;
using System.Reflection;

namespace FileCompositions.Core.File.Specialized.Dll.Resource.Abstract;

internal abstract class AbstractDllResource(IFileContext context, string name)
    : AbstractFileResource(context, Filename.CreateDll(name)), IDllResource
{
    public Assembly? Assembly { get; set; }
}
