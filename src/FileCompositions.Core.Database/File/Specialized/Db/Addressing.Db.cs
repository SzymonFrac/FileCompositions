using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Database.File.Specialized.Db;

public static partial class Addressing
{
    private sealed record Db : Extension
    {
        public override string ToString() => ".db";
    }

    extension(Extension)
    {
        public static Extension Db => new Db();
    }

    extension(Filename)
    {
        public static Filename CreateDb(string name) => Filename.Create(name, Extension.Db);
    }
}
