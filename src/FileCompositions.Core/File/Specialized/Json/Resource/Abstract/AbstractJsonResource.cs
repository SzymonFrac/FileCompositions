using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Specialized.Json.Definition.Extensions;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Specialized.Json.Resource.Abstract;

internal abstract class AbstractJsonResource<TData>(IFileContext context, string name, JsonFormat format) :
    AbstractFileResource(context, FileSystemResourceName.CreateJson(name)), IJsonResource<TData>
{
    public JsonFormat Format { get; } = format;
}
