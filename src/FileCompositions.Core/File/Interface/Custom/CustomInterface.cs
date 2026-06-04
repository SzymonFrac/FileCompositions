using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Interface.Custom;

public static class CustomInterface
{
    extension<TOwnership>(ICustomInterface<TOwnership, RequiredInRequired> @interface)
        where TOwnership : DefinitionOwnership
    {
        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(ICustomInterface<StrictDefinition, OptionalInRequired> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(ICustomInterface<ExternalDefinition, OptionalInRequired> @interface)
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

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(ICustomInterface<StrictDefinition, OptionalInOptional> @interface)
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

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(ICustomInterface<ExternalDefinition, OptionalInOptional> @interface)
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

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }
}
