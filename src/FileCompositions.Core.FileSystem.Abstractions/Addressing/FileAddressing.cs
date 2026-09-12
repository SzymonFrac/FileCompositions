namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public sealed record FileAddressing
{
    private readonly DirectoryAddressing _directoryAddressing;

    public Filename Filename { get; }
    public Address Address => _directoryAddressing.Address;
    public Location Location => Address.With(Filename);

    public FileAddressing(DirectoryAddressing directoryAddressing, Filename filename) =>
        (_directoryAddressing, Filename) = (directoryAddressing, filename);
}
