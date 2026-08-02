using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) =>
            directory.Context.FileSystem.CreateAsync(directory.Address, cancellationToken);
    }

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {
        internal async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await directory.Context.FileSystem.ExistsAsync(directory.Address, cancellationToken))
                throw new ExternalRequiredDirectoryMissingException("A required, external directory must exist.")
                {
                    Address = directory.Address,
                    Key = directory.Key
                };
        }
    }

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
