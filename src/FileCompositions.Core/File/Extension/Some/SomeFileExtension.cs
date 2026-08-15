namespace FileCompositions.Core.File.Extension.Some;

public abstract partial record SomeFileExtension : FileExtension
{
    private readonly string _value;

    public ReadOnlySpan<char> Value => _value;

    internal protected SomeFileExtension(string value) => _value = value;

    public sealed override string Affix(ReadOnlySpan<char> name) => string.Concat(name, _value);
    public sealed override string Affix(string name) => name + _value;
    public sealed override string ToString() => _value;
}
