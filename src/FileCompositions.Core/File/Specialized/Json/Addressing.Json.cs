using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Json;

public static partial class Addressing
{
    private sealed record Json : Extension
    {
        public override string ToString() => ".json";
    }

    extension(Extension)
    {
        public static Extension Json => new Json();
    }

    extension(Filename)
    {
        public static Filename CreateJson(string name) => Filename.Create(name, Extension.Json);
    }
}
