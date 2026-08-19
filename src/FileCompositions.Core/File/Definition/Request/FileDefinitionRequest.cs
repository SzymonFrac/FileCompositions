using FileCompositions.Core.File.Context;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Request;

internal delegate TDefinition FileDefinitionRequest<TOwnership, TPlacement, TDefinition>(in IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;
