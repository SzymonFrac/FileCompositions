using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Specialized.Json.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Resource;

public interface IJsonResource<TData> : IJsonQuality<Ownership.External, Placement.RequiredInRequired, TData>, IFileResource;