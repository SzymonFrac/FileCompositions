using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Unspecified;

public static partial class Addressing
{
    private sealed record Unspecified : Extension
    {
        public override string ToString() => string.Empty;
    }

    extension(Extension)
    {
        public static Extension Unspecified => new Unspecified();
    }

    extension(Filename)
    {
        public static Filename CreateUnspecified(string name) => Filename.Create(name, Extension.Unspecified);
    }
}
