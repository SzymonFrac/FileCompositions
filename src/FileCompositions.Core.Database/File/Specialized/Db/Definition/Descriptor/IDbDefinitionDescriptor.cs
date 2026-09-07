using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;

internal delegate IDbDefinition<TOwnership, TPlacement> DbDefinitionDescriptor<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context)
    where TOwnership : Ownership
    where TPlacement : Placement;
