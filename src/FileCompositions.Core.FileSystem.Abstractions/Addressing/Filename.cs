namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public readonly record struct Filename
{
    private readonly string _fullName;
    public ReadOnlySpan<char> Name => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(..dotIntext)
        : _fullName.AsSpan();
    public ReadOnlySpan<char> Extension => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(dotIntext..)
        : [];

    private Filename(string fullname) => _fullName = fullname;
    public static Filename Create(string name, Extension extension) => new(name + extension);

    public override string ToString() => _fullName;
}
