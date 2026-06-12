using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Interface;

internal static class FileInterface
{
    extension<TOwnership>(IFileInterface<TOwnership, RequiredInRequired> @interface)
        where TOwnership : DefinitionOwnership
    {
        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<StrictDefinition, OptionalInRequired> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<ExternalDefinition, OptionalInRequired> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;
    }

    extension(IFileInterface<StrictDefinition, OptionalInOptional> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation().Address, cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation().Address, cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;
    }

    extension(IFileInterface<ExternalDefinition, OptionalInOptional> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;
    }
}
