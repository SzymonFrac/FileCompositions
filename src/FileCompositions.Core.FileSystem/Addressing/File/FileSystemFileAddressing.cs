using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.FileSystem.Addressing.File;

public sealed record FileSystemFileAddressing : FileSystemAddressing
{
    private readonly FileSystemDirectoryAddressing _directoryAddressing;

    public FileSystemFilename Filename { get; }
    public FileSystemAddress Address => _directoryAddressing.Address;
    public FileSystemLocation Location => Address.With(Filename);

    public FileSystemFileAddressing(FileSystemDirectoryAddressing directoryAddressing, FileSystemFilename filename) =>
        (_directoryAddressing, Filename) = (directoryAddressing, filename);
}
