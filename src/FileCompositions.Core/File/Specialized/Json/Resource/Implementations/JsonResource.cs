using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.File.Specialized.Json.Resource.Abstract;

namespace FileCompositions.Core.File.Specialized.Json.Resource.Implementations;

internal sealed class JsonResource<TData>(IFileContext context, string name, JsonFormat format)
    : AbstractJsonResource<TData>(context, name, format);
