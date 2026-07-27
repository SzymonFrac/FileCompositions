using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Quality.Ext;

public static partial class FileQualityExt
{
    extension<TOwnership>(IFileQuality<TOwnership, RequiredInRequired> file)
        where TOwnership : DefinitionOwnership
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.OpenReadAsync(file.GetLocation(), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.OpenWriteAsync(file.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.OpenAppendAsync(file.GetLocation(), cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInRequired> file)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenReadAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.OpenWriteAsync(file.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.OpenAppendAsync(file.GetLocation(), cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInRequired> file)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenReadAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenWriteAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenAppendAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }

    extension(IFileQuality<StrictDefinition, OptionalInOptional> file)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenReadAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation().Address, cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenWriteAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation().Address, cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenAppendAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }

    extension(IFileQuality<ExternalDefinition, OptionalInOptional> file)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenReadAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenWriteAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await file.Context.StorageBackend.OpenAppendAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }
}
