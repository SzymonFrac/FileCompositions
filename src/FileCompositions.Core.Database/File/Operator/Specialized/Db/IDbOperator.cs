using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Operator.Specialized.Db;

public interface IDbOperator<TOwnership, TPlacement> : IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;
