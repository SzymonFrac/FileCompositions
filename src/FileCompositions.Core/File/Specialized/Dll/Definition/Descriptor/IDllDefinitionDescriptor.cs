using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;

internal delegate IDllDefinition<TOwnership, TPlacement> DllDefinitionDescriptor<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context)
    where TOwnership : Ownership
    where TPlacement : Placement;