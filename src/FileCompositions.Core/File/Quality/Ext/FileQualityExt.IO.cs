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
            file.RequestFileSystemAsync((fs, ct) => fs.OpenReadAsync(file.GetLocation(), ct), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.OpenWriteAsync(file.GetLocation(), ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.OpenAppendAsync(file.GetLocation(), ct), cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenReadAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.OpenWriteAsync(file.GetLocation(), ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.OpenAppendAsync(file.GetLocation(), ct), cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenReadAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenWriteAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenAppendAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenReadAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenWriteAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenAppendAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }

    extension(IFileQuality<ExternalDefinition, OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenReadAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenWriteAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
                await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    ? await fs.OpenAppendAsync(file.GetLocation(), ct).ConfigureAwait(false)
                    : default,
                cancellationToken);
    }
}
