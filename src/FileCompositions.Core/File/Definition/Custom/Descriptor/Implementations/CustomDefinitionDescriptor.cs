using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Custom.Descriptor.Implementations;

internal sealed class CustomDefinitionDescriptor<TOwnership, TPlacement, TDefinition>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>(directoryKey, key, name),
    ICustomDefinitionDescriptor<TOwnership, TPlacement, TDefinition>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>
{
    public required ICustomDefinition<TOwnership, TPlacement, TDefinition> Definition { get; init; }
    public override TDefinition Activate(in IFileContext context) =>
        throw new System.Exception();
        //Definition.Create(in context, Key, StorageResourceName.Create(Name, Definition.Extension));
}
