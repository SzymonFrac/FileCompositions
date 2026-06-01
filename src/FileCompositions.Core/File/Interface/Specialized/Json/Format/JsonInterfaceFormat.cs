using System.Text.Json;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Format;

public sealed record JsonInterfaceFormat(JsonSerializerOptions JsonSerializerOptions)
{
    public static JsonInterfaceFormat Default { get; } = new(JsonSerializerOptions.Default);
};