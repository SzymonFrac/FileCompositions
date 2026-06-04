namespace FileCompositions.Core.File.Interface.Specialized.Json.ReadResult.Implementations;

public sealed record JsonSomeResult<T>(T Value) : JsonReadResult<T>;
