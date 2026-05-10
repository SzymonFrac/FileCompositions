using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Descriptor;

internal interface IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement>
    where TDefinition : IFileDefinition<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    DirectoryDefinitionKey DirectoryKey { get; }
    FileDefinitionKey Key { get; }
    FileDefinitionKey WithKeyIfNull(FileDefinitionKey key);

    TDefinition Activate(in IFileContext context);
}