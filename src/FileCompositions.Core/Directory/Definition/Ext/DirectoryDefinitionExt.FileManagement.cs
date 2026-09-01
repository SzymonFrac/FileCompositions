using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {

    }

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {

    }

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            directory.RequestFileSystemAsync((fss, ct) => fss.CreateAsync(ct), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            directory.RequestFileSystemAsync((fss, ct) => fss.DeleteAsync(ct), cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.RequestFileSystemAsync((fss, ct) => fss.ExistsAsync(ct), cancellationToken);
    }
}
