using FileCompositions.Core.File.Options;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Options;

public partial interface IJsonOptions<TData> : IFileOptions<IJsonOptions<TData>>
{
    IJsonOptions<TData> UseSerializerOptions(JsonSerializerOptions serializerOptions);
}
