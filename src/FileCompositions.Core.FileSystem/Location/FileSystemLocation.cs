using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.FileSystem.Location;

public abstract record FileSystemLocation(FileSystemAddress Address, FileSystemFilename Name);
