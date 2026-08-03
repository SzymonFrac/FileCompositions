using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension<TOwnership>(IFileDefinition<TOwnership, RequiredInRequired> file)
        where TOwnership : DefinitionOwnership
    {

    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> file)
    {
        internal Task CreateAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.CreateLocationAsync(ct).AsTask(), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsLocationAsync(ct).ConfigureAwait(false))
                    await fss.DeleteLocationAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsLocationAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsLocationAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                var addressExists = await fss.ExistsAddressAsync(ct).ConfigureAwait(false);
                if (addressExists)
                    await fss.CreateLocationAsync(ct).ConfigureAwait(false);

                return addressExists;
            },
                cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsLocationAsync(ct).ConfigureAwait(false))
                    await fss.DeleteLocationAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsLocationAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsLocationAsync(ct).AsTask(), cancellationToken);
    }
}
