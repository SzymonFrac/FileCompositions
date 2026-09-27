namespace FileCompositions.Core.FileSystem.Addressing.Abstractions;

public readonly record struct Filename
{
    public string Name { get; }
    public Extension Extension { get; }
    
    private Filename(string name, Extension extension) => (Name, Extension) = (name, extension);
    public static Filename Create(string name, Extension extension) => new(name, extension);
    // this should be raw file
    public static Filename Create(string name) => new(name, Extension.None.Value);

    public override string ToString() => Name + Extension;
}
