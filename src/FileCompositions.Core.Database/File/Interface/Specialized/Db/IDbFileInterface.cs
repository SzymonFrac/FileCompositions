using FileCompositions.Core.File.Interface;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Interface.Specialized.Db;

public interface IDbFileInterface<TPlacement> : IFileInterface<TPlacement>
    where TPlacement : DefinitionPlacement;