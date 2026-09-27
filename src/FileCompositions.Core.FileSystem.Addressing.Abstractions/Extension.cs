namespace FileCompositions.Core.FileSystem.Addressing.Abstractions;

public abstract record Extension
{
    public sealed record Some : Extension
    {
        private readonly string _value;
        private Some(string value) => _value = value;
        internal static Some Create(string value) => new(value);
        public override string ToString() => _value;
    }
    // You could have raw file though,
    // Which would be the 'definition' for the none?
    public sealed record None : Extension
    {
        public static Extension Value => field ??= new None();
        public override string ToString() => string.Empty;
    }
}
