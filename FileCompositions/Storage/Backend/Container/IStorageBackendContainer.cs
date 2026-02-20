namespace FileCompositions.Core.Storage.Backend.Container;

internal interface IStorageBackendContainer
{
    IStorageBackend GetStorageBackend<TBackend>()
        where TBackend : class, IStorageBackend;
}

