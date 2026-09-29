using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Descriptor;

internal delegate IUnspecifiedDefinition<TOwnership, TPlacement> UnspecifiedDefinitionDescriptor<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context)
    where TOwnership : Ownership
    where TPlacement : Placement;