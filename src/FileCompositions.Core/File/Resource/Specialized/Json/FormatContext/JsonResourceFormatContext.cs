using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;

public record JsonResourceFormatContext(JsonSerializerOptions JsonSerializerOptions)
{
    public static readonly JsonResourceFormatContext Default = new(JsonSerializerOptions.Default);
};