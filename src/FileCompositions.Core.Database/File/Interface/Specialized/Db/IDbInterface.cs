using FileCompositions.Core.File.Interface;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Interface.Specialized.Db;

public interface IDbInterface<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;