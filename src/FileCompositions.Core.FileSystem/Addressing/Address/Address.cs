namespace FileCompositions.Core.FileSystem.Addressing;

public abstract record Address
{
    protected string Value { get; }

    public ReadOnlySpan<char> FullPath => Value;

    protected Address(ReadOnlySpan<char> value) => Value = value.ToString();

    public abstract Location With(Filename name);
    public override string ToString() => Value;
}
