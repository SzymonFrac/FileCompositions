using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.FileSystem.Location;

public abstract record FileSystemLocation(FileSystemAddress Address, FileName Name);
