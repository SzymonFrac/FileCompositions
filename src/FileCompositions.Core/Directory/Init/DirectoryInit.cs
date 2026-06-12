using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Init;

internal static class DirectoryInit
{
    extension(IDirectoryInit<StrictDefinition, RequiredDefinition> init)
    {
        public ValueTask InitAsync(CancellationToken cancellation = default) =>
            init.StorageBackend.CreateAsync(init.GetAddress(), cancellation);
    }

    extension(IDirectoryInit<ExternalDefinition, RequiredDefinition> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellation = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetAddress(), cancellation))
                throw new ExternalRequiredDirectoryMissingException("A required, external directory must exist.")
                {
                    Address = init.GetAddress(),
                    Key = init.GetKey()
                };
        }
    }

    extension(IDirectoryInit<StrictDefinition, OptionalDefinition> init)
    {

    }

    extension(IDirectoryInit<ExternalDefinition, OptionalDefinition> init)
    {

    }
}
