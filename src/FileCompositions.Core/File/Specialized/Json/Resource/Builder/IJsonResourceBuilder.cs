using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Resource.Builder;

public interface IJsonResourceBuilder<TData> : IFileResourceBuilder
{
    IJsonResourceBuilder<TData> WithName(string name);
    IJsonResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions serializerOptions);

    internal IJsonResource<TData> Build(in IFileContext context);
}
