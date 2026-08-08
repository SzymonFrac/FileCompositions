using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;

//internal interface IDllDefinitionDescriptor<TOwnership, TPlacement>
//    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement;

internal delegate IDllDefinition<TOwnership, TPlacement> DllDefinitionDescriptor<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;