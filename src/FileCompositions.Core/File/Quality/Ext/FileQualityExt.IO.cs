using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Quality.Ext;

public static partial class FileQualityExt
{
    extension<TOwnership>(IFileQuality<TOwnership, RequiredInRequired> io)
        where TOwnership : DefinitionOwnership
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            io.Context.StorageBackend.OpenReadAsync(io.GetLocation(), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            io.Context.StorageBackend.OpenWriteAsync(io.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            io.Context.StorageBackend.OpenAppendAsync(io.GetLocation(), cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInRequired> io)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenReadAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            io.Context.StorageBackend.OpenWriteAsync(io.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            io.Context.StorageBackend.OpenAppendAsync(io.GetLocation(), cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInRequired> io)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenReadAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenWriteAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenAppendAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }

    extension(IFileQuality<StrictDefinition, OptionalInOptional> io)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenReadAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation().Address, cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenWriteAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation().Address, cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenAppendAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }

    extension(IFileQuality<ExternalDefinition, OptionalInOptional> io)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenReadAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenWriteAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await io.Context.StorageBackend.ExistsAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                ? await io.Context.StorageBackend.OpenAppendAsync(io.GetLocation(), cancellationToken).ConfigureAwait(false)
                : default;
    }
}
