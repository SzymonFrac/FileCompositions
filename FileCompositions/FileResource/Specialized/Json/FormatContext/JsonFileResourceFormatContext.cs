using System.Text.Json;

namespace FileCompositions.Core.FileResource.Specialized.Json.FormatContext;

public readonly record struct JsonFileResourceFormatContext(JsonSerializerOptions JsonSerializerOptions);