using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Definition.Db.Descriptor;

internal interface IDbDefinitionDescriptor<TOwnership, TPlacement>
    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
