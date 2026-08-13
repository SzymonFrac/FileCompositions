using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;

public interface IDbDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>, IDbDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal IDbDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
