using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Extension;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;

internal sealed class DllDefinition<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context, string name) :
    AbstractDllDefinition<TOwnership, TPlacement>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class DllDefinition : IDllDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".dll");
    private DllDefinition() { }

    public static IDllResource Convert(in IFileContext context, string name) =>
        DllResourceBuilderFactory.Default
            .CreateDefault()
            .WithName(name)
            .Build(context);
}
