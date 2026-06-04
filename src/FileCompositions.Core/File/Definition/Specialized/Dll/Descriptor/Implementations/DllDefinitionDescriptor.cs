using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Dll.Init.Policy;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Descriptor.Implementations;

internal sealed class DllDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>(directoryKey, key, name),
    IDllDefinitionDescriptor<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public required IDllDefinitionInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override IDllDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
        new DllDefinition<TOwnership, TPlacement>(context, Key, Name)
        {
            InitPolicy = InitPolicy
        };
}
