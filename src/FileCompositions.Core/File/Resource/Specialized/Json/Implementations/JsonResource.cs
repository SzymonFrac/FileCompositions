using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Specialized.Json.Abstract;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Implementations;

internal sealed class JsonResource<TData>(IFileContext context, string name, JsonInterfaceFormat format)
    : AbstractJsonResource<TData>(context, name, format);
