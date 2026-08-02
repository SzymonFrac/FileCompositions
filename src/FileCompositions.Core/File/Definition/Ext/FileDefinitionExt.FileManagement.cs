using FileCompositions.Core.File.Quality.Ext;
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
            file.RequestFileSystemAsync((fs, ct) => fs.CreateAsync(file.GetLocation(), ct).AsTask(), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
            {
                if (await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false))
                    await fs.DeleteAsync(file.GetLocation(), ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.ExistsAsync(file.GetLocation(), ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.ExistsAsync(file.GetLocation(), ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
            {
                var addressExists = await fs.ExistsAsync(file.GetLocation().Address, ct).ConfigureAwait(false);
                if (addressExists)
                    await fs.CreateAsync(file.GetLocation(), ct).ConfigureAwait(false);

                return addressExists;
            },
                cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync(async (fs, ct) =>
            {
                if (await fs.ExistsAsync(file.GetLocation(), ct).ConfigureAwait(false))
                    await fs.DeleteAsync(file.GetLocation(), ct).ConfigureAwait(false);
            },
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.ExistsAsync(file.GetLocation(), ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.RequestFileSystemAsync((fs, ct) => fs.ExistsAsync(file.GetLocation(), ct).AsTask(), cancellationToken);
    }
}
