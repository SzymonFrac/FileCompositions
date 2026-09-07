using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Specialized.Dll.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Resource;

// Make so that <ExternalDefinition, RequiredInRequired> is inherintly resource
public interface IDllResource : IDllQuality<Ownership.External, Placement.RequiredInRequired>, IFileResource;
