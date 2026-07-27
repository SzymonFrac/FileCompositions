using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor.Implementations;

internal sealed class DllDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>(directoryKey, key, name),
    IDllDefinitionDescriptor<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public required IDllInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override IDllDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
        new DllDefinition<TOwnership, TPlacement>(context, Key, Name)
        {
            InitPolicy = InitPolicy
        };
}
