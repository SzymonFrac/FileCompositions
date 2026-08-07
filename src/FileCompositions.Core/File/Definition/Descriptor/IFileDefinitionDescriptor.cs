using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Descriptor;

//internal interface IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>
//    where TOwnership : DefinitionOwnership
//    where TPlacement : DefinitionPlacement
//    where TDefinition : IFileDefinition<TOwnership, TPlacement>
//{
//    DirectoryDefinitionKey DirectoryKey { get; }
//    FileDefinitionKey Key { get; }


//    internal TDefinition Activate(in IFileContext context);
//}

internal delegate TDefinition FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>(FileDefinitionKey key, IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;

internal delegate TDefinition FileDefinitionRequestDescriptor<TOwnership, TPlacement, TDefinition>(IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>;

// there would be specialized descriptors that know the type but not the qualities?
// then they can be boxed down in definitionBuilder?