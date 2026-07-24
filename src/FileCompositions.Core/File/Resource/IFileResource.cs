using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource;

//May be not needed anymore
public interface IFileResource : IFileQuality<ExternalDefinition, RequiredInRequired>;