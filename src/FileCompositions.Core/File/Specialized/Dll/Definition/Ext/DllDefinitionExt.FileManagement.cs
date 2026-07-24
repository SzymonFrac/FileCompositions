using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension(IDllDefinition<StrictDefinition, RequiredInRequired> dll)
    {

    }

    extension(IDllDefinition<ExternalDefinition, RequiredInRequired> dll)
    {

    }

    extension(IDllDefinition<StrictDefinition, OptionalInRequired> dll)
    {
        public async ValueTask CreateAsync(CancellationToken cancellationToken = default)
        {
            if (!await dll.Context.StorageBackend.ExistsAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await dll.Context.StorageBackend.OpenCreateAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false);

                await using var @default = typeof(IDllDefinition<,>).Assembly
                    .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                await @default.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInRequired> dll)
    {

    }

    extension(IDllDefinition<StrictDefinition, OptionalInOptional> dll)
    {
        public async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await dll.Context.StorageBackend.ExistsAsync(dll.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
            {
                await using var stream = await dll.Context.StorageBackend.OpenCreateAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false);

                await using var @default = typeof(IDllDefinition<,>).Assembly
                    .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                await @default.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            }

            return addressExists;
        }
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInOptional> dll)
    {

    }
}
