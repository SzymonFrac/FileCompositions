using FileCompositions.Core.File.Definition.Specialized.Json.ResourceSchema.Extensions;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;
using Microsoft.Extensions.Hosting;

namespace FileCompositions.Extensions.Host.Schema.Directory.Extensions;

public static class HostFilesInDirectoryDefinitionBuilder
{
    //extension<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> builder)
    //    where TOwnership : DefinitionOwnership
    //    where TNecessity : DefinitionNecessity
    //    where TBackend : class, IStorageBackend
    //{
    //    public IFiledDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> File(Action<IHostResourceSchemaFileRegistrar> config)
    //    {
    //        // It would have to return something not void cause the directory register still needs to register the correct qualities...
    //    }
    //}

    //extension<TOwnership, TNecessity>(IDirectoryDefinitionBuilder<TOwnership, TNecessity> builder)
    //    where TOwnership : DefinitionOwnership
    //    where TNecessity : DefinitionNecessity
    //{
    //    public IFiledDirectoryDefinitionBuilder<TOwnership, TNecessity> File(Action<IHostResourceSchemaFileRegistrar> config)
    //    {
    //        new HostResourceSchemaFileRegistrar();
    //    }
    //}

    //extension<TOwnership, TNecessity>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
    //    where TOwnership : DefinitionOwnership
    //    where TNecessity : DefinitionNecessity
    //{
    //    public IFiledDirectoryDefinitionBuilder<TOwnership, TNecessity> WithFiles(Action<IHostResourceSchemaFileRegistrar> config)
    //    {
    //        new HostResourceSchemaFileRegistrar();
    //    }
    //}
}

internal class SomeStorageBackend : IStorageBackend
{
    private static void Main()
    {
        IHostBuilder var = null!;
        var.ConfigureFileResources(config =>
        {
            config.ConfigureRegistries(dirs => dirs
                .Store(config => config
                    .Define(dir => dir
                        .Required()
                        .External()
                        .ToStorageBackend<SomeStorageBackend>()
                        .WithAddress(null!)
                        .WithKey(new(1)))
                    .WithFiles(files => files
                        .DefineJson(json => json
                            .Create<object>()
                            .Optional()))));
        });
    }




    public ValueTask Create(StorageAddress address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask Create(StorageLocation location, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<StorageResourceName> EnumerateResources(StorageAddress address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> Exists(StorageAddress address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}