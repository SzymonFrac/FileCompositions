using FileCompositions.Core.File.Context;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition.Request;

internal delegate TDefinition FileDefinitionRequest<TOwnership, TPlacement, TDefinition>(in IFileContext context)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;
