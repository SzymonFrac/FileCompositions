using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Specialized.Unspecified.Resource.Abstract;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource.Implementations;

internal sealed class UnspecifiedResource(IFileContext context, string name) : AbstractUnspecifiedResource(context, name);
