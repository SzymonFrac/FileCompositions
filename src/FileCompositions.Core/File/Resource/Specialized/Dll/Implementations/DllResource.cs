using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Specialized.Dll.Abstract;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Implementations;

internal class DllResource(IFileContext context, string name) : AbstractDllResource(context, name);
