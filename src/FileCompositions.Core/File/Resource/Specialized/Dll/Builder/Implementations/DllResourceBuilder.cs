using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;
using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.File.Resource.Specialized.Dll.Context.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Dll.Implementations;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Implementations;

internal class DllResourceBuilder : IDllResourceBuilder
{
    private string? name;

    public IDllResourceBuilder WithName(string n)
    {
        name = n;
        return this;
    }

    public IDllResource Build(IDirectoryLocation directory)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var resourceName = StorageResourceName.CreateDll(name);
        var context = new DllResourceContext(directory);

        var dll = new DllResource(context, resourceName);
        return dll;
    }

    IFileResourceBuilder IFileResourceBuilder.WithName(string name) => WithName(name);
}
