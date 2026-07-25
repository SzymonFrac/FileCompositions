using FileCompositions.Core.File.Specialized.Dll.Quality;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Resource;

public interface IDllResource : IDllQuality<ExternalDefinition, RequiredInRequired>;
