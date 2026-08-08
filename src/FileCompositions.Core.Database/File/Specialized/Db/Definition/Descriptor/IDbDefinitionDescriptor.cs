using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;

//internal interface IDbDefinitionDescriptor<TOwnership, TPlacement>
//    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement;

internal delegate IDbDefinition<TOwnership, TPlacement> DbDefinitionDescriptor<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;
