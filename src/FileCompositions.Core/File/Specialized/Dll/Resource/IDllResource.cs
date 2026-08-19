using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Specialized.Dll.Quality;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Resource;

// Make so that <ExternalDefinition, RequiredInRequired> is inherintly resource
public interface IDllResource : IDllQuality<ExternalDefinition, RequiredInRequired>, IFileResource;
