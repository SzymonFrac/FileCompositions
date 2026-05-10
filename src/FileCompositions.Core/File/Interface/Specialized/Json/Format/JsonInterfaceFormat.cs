using System.Text.Json;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Format;

public record JsonInterfaceFormat(JsonSerializerOptions JsonSerializerOptions)
{
    public static readonly JsonInterfaceFormat Default = new(JsonSerializerOptions.Default);
};