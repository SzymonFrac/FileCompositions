using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource.Abstract;

internal abstract class AbstractUnspecifiedResource(IFileContext context, string name)
    : AbstractFileResource(context, Filename.CreateUnspecified(name)), IUnspecifiedResource;
