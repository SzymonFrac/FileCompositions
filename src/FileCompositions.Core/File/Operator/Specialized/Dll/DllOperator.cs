using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Operator.Specialized.Dll;

public static class DllOperator
{
    extension(IDllOperator<StrictDefinition, RequiredInRequired> dll)
    {

    }

    extension(IDllOperator<ExternalDefinition, RequiredInRequired> dll)
    {

    }

    extension(IDllOperator<StrictDefinition, OptionalInRequired> dll)
    {
        public async ValueTask CreateAsync(CancellationToken cancellationToken = default)
        {
            if (!await dll.StorageBackend.ExistsAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await dll.StorageBackend.OpenCreateAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false);

                await using var @default = typeof(IDllOperator<,>).Assembly
                    .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                await @default.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension(IDllOperator<ExternalDefinition, OptionalInRequired> dll)
    {

    }

    extension(IDllOperator<StrictDefinition, OptionalInOptional> dll)
    {
        public async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await dll.StorageBackend.ExistsAsync(dll.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
            {
                await using var stream = await dll.StorageBackend.OpenCreateAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false);

                await using var @default = typeof(IDllOperator<,>).Assembly
                    .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                await @default.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            }

            return addressExists;
        }
    }

    extension(IDllOperator<ExternalDefinition, OptionalInOptional> dll)
    {

    }
}
