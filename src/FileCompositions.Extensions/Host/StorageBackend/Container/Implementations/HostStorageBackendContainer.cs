using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.Container;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Container.Implementations;

internal class HostStorageBackendContainer(ref IServiceProvider sp) : IStorageBackendContainer
{
    private readonly IServiceProvider _sp = sp;
    public IStorageBackend GetStorageBackend<TBackend>()
        where TBackend : class, IStorageBackend =>
            _sp.GetRequiredService<TBackend>();

}
