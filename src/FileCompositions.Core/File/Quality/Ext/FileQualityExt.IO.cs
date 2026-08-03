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
            file.RequestFileSystemAsync((fss, ct) => fss.OpenReadAsync(ct), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.OpenWriteAsync(ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.OpenAppendAsync(ct), cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenReadAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.OpenWriteAsync(ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.OpenAppendAsync(ct), cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenReadAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenReadAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenReadAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
                await fss.ExistsLocationAsync(ct).ConfigureAwait(false)
                    ? await fss.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }
}
