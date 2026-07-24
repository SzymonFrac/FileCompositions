using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Specialized.Dll.Resource.Abstract;

namespace FileCompositions.Core.File.Specialized.Dll.Resource.Implementations;

internal sealed class DllResource(IFileContext context, string name) : AbstractDllResource(context, name);
