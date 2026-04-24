using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Factory.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Dll.Context;
using FileCompositions.Core.File.Resource.Specialized.Dll.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;

internal class AbstractDllDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IDllResourceContext context, StorageResourceName name)
    : AbstractDllDefinition(context, name), IDllDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public FileDefinitionKey Key { get; } = key;
}

internal abstract class AbstractDllDefinition(IDllResourceContext context, StorageResourceName name)
    : DllResource(context, name), IDllDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".dll");

    public static IDllResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDllResourceBuilder>? config = default)
    {
        var factory = new DllResourceBuilderFactory();
        var builder = factory.CreateDefault();
        config?.Invoke(builder);
        var dll = builder.Build(directory);
        return dll;
    }

    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}

