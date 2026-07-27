using FileCompositions.Core.Database.File.Specialized.Db.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;

internal interface IDbDefinitionDescriptor<TOwnership, TPlacement>
    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
