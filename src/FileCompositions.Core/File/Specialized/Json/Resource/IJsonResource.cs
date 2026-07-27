using FileCompositions.Core.File.Specialized.Json.Quality;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Resource;

public interface IJsonResource<TData> : IJsonQuality<ExternalDefinition, RequiredInRequired, TData>;