namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public readonly record struct Filename
{
    private readonly string _fullName;
    private readonly Index _dotIndex;

    public ReadOnlySpan<char> Name => _fullName.AsSpan(.._dotIndex);
    public ReadOnlySpan<char> Extension => _fullName.AsSpan(_dotIndex..);

    private Filename(string fullname, Index dotIndex) => (_fullName, _dotIndex) = (fullname, dotIndex);
    public static Filename Create(string name, in Extension extension) => new(name + extension, extension.DotIndex);

    public void Deconstruct(out string name, out string extension) => (name, extension) = (_fullName[.._dotIndex], _fullName[_dotIndex..]);
    public override string ToString() => _fullName;
}
