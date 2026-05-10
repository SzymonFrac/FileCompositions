using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.Interface.Extensions;

// Is the interface ON the directory on *to* the file
internal static class DirectoryInterfaceNecessity
{
    extension(IDirectoryInterface<RequiredDefinition> @interface)
    {
        // This would be:
        // Looking for many files in a directory (EnumerateFiles<TFile> ...)
    }

    extension(IDirectoryInterface<OptionalDefinition> @interface)
    {
        public ValueTask<bool> Exists(StorageResourceName name, CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Address.With(name), cancellationToken);

        // Looking for many files in a directory optionally (EnumerateFiles<TFile>? ...)
    }
}
