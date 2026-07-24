using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Format;

public sealed record JsonFormat(JsonSerializerOptions JsonSerializerOptions)
{
    public static JsonFormat Default { get; } = new(JsonSerializerOptions.Default);
};
