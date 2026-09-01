using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.FileSystem.Addressing.Directory;

public sealed record FileSystemDirectoryAddressing(FileSystemAddress Address) : FileSystemAddressing;
