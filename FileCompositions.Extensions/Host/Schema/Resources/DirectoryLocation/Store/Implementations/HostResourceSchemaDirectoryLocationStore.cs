using FileCompositions.Core.DirectoryLocation.Builder;
using FileCompositions.Core.DirectoryLocation.Builder.Factory.Implementations;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Schema.Resources.DirectoryLocation.Store;
using FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;
using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Core.Storage.Backend.Provider.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Resources.DirectoryLocation.Store.Implementations;

internal class HostResourceSchemaDirectoryLocationStore : IResourceSchemaDirectoryLocationStore
{
    private DirectoryLocationKey key;
    private Action<IDirectoryLocationBuilder>? builderConfig;
    public IResourceSchemaDirectoryLocationStoreRegister UseKey(DirectoryLocationKey k)
    {
        key = k;
        return this;
    }
    public void Register(Action<IDirectoryLocationBuilder> config) =>
        builderConfig = config;

    public IDirectoryLocationDescriptor BuildDescriptor()
    {
        var factory = new DirectoryLocationBuilderFactory();
        var builder = factory.Create(new StorageBackendProvider<LocalDiskStorageBackend>());
        builderConfig!(builder);

        var descriptor = builder.BuildDescriptor(key);
        return descriptor;
    }

}
