using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition.Descriptor;

internal delegate FileDefinitionRequest<TOwnership, TPlacement, TDefinition> FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>(FileDefinitionKey key)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;