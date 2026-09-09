using static System.Environment;

namespace FileCompositions.Core.FileSystem.Addressing.Implementations;

public sealed record LocalAddress : Address
{
    private LocalAddress(ReadOnlySpan<char> value) : base(value) { }

    public static LocalAddress Create(ReadOnlySpan<char> path) =>
        path.IsWhiteSpace()
            ? throw new ArgumentException("Address cannot be empty.", nameof(path))
            : new LocalAddress(Path.TrimEndingDirectorySeparator(path));
    public static LocalAddress Create(params ReadOnlySpan<string> path) =>
        new(Path.Combine(path));
    public static LocalAddress Create(SpecialFolder logical) =>
        new(GetFolderPath(logical));
    public static LocalAddress Create(SpecialFolder logical, params ReadOnlySpan<string> path) =>
        new(Path.Combine([GetFolderPath(logical), .. path]));

    public LocalAddress Extend(params ReadOnlySpan<string> path) =>
        new(Path.Combine([Value, .. path]));

    public override Location With(Filename name) => new LocalLocation(this, name);
    public override string ToString() => Value;
}
