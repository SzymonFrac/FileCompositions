using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Request;

// do properly
//internal sealed record FileDefinitionRequest<TOwnership, TPlacement, TDefinition>(
//    DirectoryDefinitionKey DirectoryKey,
//    FileDefinitionKey FileKey,
//    FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> Descriptor)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//        where TDefinition : IFileDefinition<TOwnership, TPlacement>
//{
//    public TDefinition Activate() => Descriptor();
//}

// FileDefinitionDescriptor is Func<key, context, file>
// something is Func<key, /*Func<context, file>*/ desctiptor> - that's request...
// can I say Func<keys, >
