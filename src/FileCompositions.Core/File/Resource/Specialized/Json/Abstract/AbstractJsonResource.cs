using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Specialized.Json.Extensions;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Abstract;

internal abstract class AbstractJsonResource<TData>(IFileContext context, string name, JsonInterfaceFormat format) :
    AbstractFileResource(context, FileSystemResourceName.CreateJson(name)), IJsonResource<TData>
{
    public JsonInterfaceFormat Format { get; } = format;
}
