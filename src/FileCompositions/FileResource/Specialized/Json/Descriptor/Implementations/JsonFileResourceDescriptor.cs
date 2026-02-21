using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Specialized.Descriptor;
using FileCompositions.Core.FileResource.Specialized.Json.Context.Implementations;
using FileCompositions.Core.FileResource.Specialized.Json.FormatContext;
using FileCompositions.Core.FileResource.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized.Json.Descriptor.Implementations;

internal class JsonFileResourceDescriptor<TData>(DirectoryLocationKey key, StorageResourceName name, JsonFileResourceFormatContext format,
    IReadOnlyCollection<Func<IJsonFileResource<TData>, Task>>? validations) : IJsonFileResourceDescriptor<TData>
{
    private readonly IReadOnlyCollection<Func<IJsonFileResource<TData>, Task>> _validations = validations ?? [];
    public DirectoryLocationKey DirectoryLocationKey { get; } = key;
    public StorageResourceName Name { get; } = name;
    public JsonFileResourceFormatContext Format { get; } = format;

    public IJsonFileResource<TData> Activate(IDirectoryLocation directory)
    {
        var context = new JsonFileResourceContext(directory);
        var json = new JsonFileResource<TData>(context, Name, Format);

        foreach (var validate in _validations)
            validate(json);

        return json;
    }

    ISpecializedFileResource ISpecializedFileResourceDescriptor.Activate(IDirectoryLocation directory) => Activate(directory);
}
