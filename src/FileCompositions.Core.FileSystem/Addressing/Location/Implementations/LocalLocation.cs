namespace FileCompositions.Core.FileSystem.Addressing.Implementations;

public sealed record LocalLocation(Address Address, Filename Name) : Location(Address, Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
