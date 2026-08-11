using FileCompositions.Core.File.Context;

namespace FileCompositions.Core.File.Resource.Request;

internal delegate TResource FileResourceRequest<TResource>(in IFileContext context)
    where TResource : IFileResource;
