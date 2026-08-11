using FileCompositions.Core.Database.File.Specialized.Db.Quality;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource;

public interface IDbResource : IDbQuality<ExternalDefinition, RequiredInRequired>, IFileResource;