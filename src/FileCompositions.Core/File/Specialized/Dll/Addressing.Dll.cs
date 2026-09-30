using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Dll;

public static partial class Addressing
{
    private sealed record Dll : Extension
    {
        public override string ToString() => ".dll";
    }

    extension(Extension)
    {
        public static Extension Dll => new Dll();
    }

    extension(Filename)
    {
        public static Filename CreateDll(string name) => Filename.Create(name, Extension.Dll);
    }
}
