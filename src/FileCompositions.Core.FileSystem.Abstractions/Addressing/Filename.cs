using System.Diagnostics;

namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public readonly record struct Filename
{
    public string Name { get; }
    public Extension Extension { get; }

    private Filename(string name, Extension extension) => (Name, Extension) = (name, extension);
    public static Filename Create(string name, Extension extension) => new(name, extension);
    public static Filename Create(string name) => new(name, Extension.None.Value);

    public override string ToString() => Extension switch
    {
        Extension.None => Name,
        Extension.Some s => Name + s.ToString(),
        _ => throw new UnreachableException()
    };
}
