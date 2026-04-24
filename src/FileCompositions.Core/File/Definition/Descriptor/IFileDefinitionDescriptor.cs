using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Descriptor;

internal interface IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDefinition : IFileDefinition<TOwnership, TNecessity>
{
    DirectoryDefinitionKey DirectoryKey { get; }
    FileDefinitionKey Key { get; }
    FileDefinitionKey WithKeyIfNull(FileDefinitionKey key);

    TDefinition Activate(in IFileContext context);
}
