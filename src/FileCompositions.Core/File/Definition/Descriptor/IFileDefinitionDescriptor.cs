using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Descriptor;

public interface IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    DirectoryDefinitionKey DirectoryKey { get; }
    FileDefinitionKey Key { get; }

    TDefinition Activate(in IFileContext context);
}