namespace FileCompositions.Core.File.Specialized.Json.ReadResult.Implementations;

public sealed record JsonSomeResult<T>(T Value) : JsonReadResult<T>;
