using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Descriptor;

internal delegate FileDefinitionRequest<TOwnership, TPlacement, TDefinition> FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>(FileDefinitionKey key)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;