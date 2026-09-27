namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public abstract record Extension
{
    public sealed record Some : Extension
    {
        private readonly string _value;
        private Some(string value) => _value = value;
        internal static Some Create(string value) => new(value);
        public override string ToString() => _value;
    }
    public sealed record None : Extension
    {
        public static Extension Value => field ??= new None();
        public override string ToString() => string.Empty;
    }
}
