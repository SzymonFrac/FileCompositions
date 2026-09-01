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
            file.RequestFileSystemAsync((fss, ct) => fss.CreateAsync(ct), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsAsync(ct).ConfigureAwait(false))
                    await fss.DeleteAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                var addressExists = await fss.AddressExistsAsync(ct).ConfigureAwait(false);
                if (addressExists)
                    await fss.CreateAsync(ct).ConfigureAwait(false);

                return addressExists;
            },
                cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsAsync(ct).ConfigureAwait(false))
                    await fss.DeleteAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }
}
