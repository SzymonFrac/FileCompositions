using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Extension.Some;
using FileCompositions.Core.File.Specialized.Dll.Definition.Abstract;
using FileCompositions.Core.File.Specialized.Dll.Extension;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.File.Specialized.Dll.Resource.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;

internal sealed class DllDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name) :
    AbstractDllDefinition<TOwnership, TPlacement>(context, key, name)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class DllDefinition : IDllDefinition
{
    public static SomeFileExtension Extension { get; } = new DllExtension();
    private DllDefinition() { }

    public static IDllResource Convert(in IFileContext context, string name) =>
        DllResourceBuilderFactory.Default
            .CreateDefault()
            .WithName(name)
            .Build(context);
}
