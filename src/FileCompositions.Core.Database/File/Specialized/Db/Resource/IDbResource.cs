using FileCompositions.Core.Database.File.Specialized.Db.Quality;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource;

public interface IDbResource : IDbQuality<Ownership.External, Placement.RequiredInRequired>, IFileResource;