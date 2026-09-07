using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource : IFileQuality<Ownership.External, Placement.RequiredInRequired>;