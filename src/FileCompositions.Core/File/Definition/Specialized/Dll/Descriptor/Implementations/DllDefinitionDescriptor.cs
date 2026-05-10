using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Descriptor.Implementations;

internal class DllDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : FileDefinitionDescriptor<IDllDefinition<TOwnership, TPlacement>, TOwnership, TPlacement>(directoryKey, key, name),
        IDllDefinitionDescriptor<TOwnership, TPlacement>
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
{
    public override IDllDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
        new DllDefinition<TOwnership, TPlacement>(Key, context, Name);
}
