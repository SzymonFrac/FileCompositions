using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.FileSystem.Location;

public abstract record FileSystemLocation(FileSystemAddress Address, FileSystemResourceName Name);
