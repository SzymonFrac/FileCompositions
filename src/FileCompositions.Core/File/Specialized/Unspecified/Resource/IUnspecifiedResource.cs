using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Specialized.Unspecified.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource;

public interface IUnspecifiedResource : IUnspecifiedQuality<Ownership.External, Placement.RequiredInRequired>, IFileResource;
