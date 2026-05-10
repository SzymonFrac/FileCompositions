using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;
using FileCompositions.Core.File.Interface.Specialized.Dll.Builder;
using FileCompositions.Core.File.Interface.Specialized.Dll.Builder.Factory.Implementations;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;

internal sealed class DllDefinition<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context, string name) :
    AbstractDllDefinition<TOwnership, TPlacement>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class DllDefinition : IDllDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".dll");
    private DllDefinition() { }

    public static IDllResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDllResourceBuilder>? config = default)
    {
        var factory = new DllResourceBuilderFactory();
        var builder = factory.CreateDefault();
        config?.Invoke(builder);

        var context = new FileContext(directory);
        var dll = builder.Build(context);
        return dll;
    }

    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}
