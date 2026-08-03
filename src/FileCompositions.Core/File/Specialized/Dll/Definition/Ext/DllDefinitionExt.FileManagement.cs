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
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            dll.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (!await fss.ExistsLocationAsync(ct).ConfigureAwait(false))
                {
                    await using var stream = await fss.OpenCreateAsync(ct).ConfigureAwait(false);

                    await using var @default = typeof(IDllDefinition<,>).Assembly
                        .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                    await @default.CopyToAsync(stream, ct).ConfigureAwait(false);
                }
            },
                cancellationToken);
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInRequired> dll)
    {

    }

    extension(IDllDefinition<StrictDefinition, OptionalInOptional> dll)
    {
        public Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            dll.RequestFileSystemAsync(async (fss, ct) =>
            {
                var addressExists = await fss.ExistsAddressAsync(ct).ConfigureAwait(false);
                if (addressExists)
                {
                    await using var stream = await fss.OpenCreateAsync(ct).ConfigureAwait(false);

                    await using var @default = typeof(IDllDefinition<,>).Assembly
                        .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                    await @default.CopyToAsync(stream, ct).ConfigureAwait(false);
                }

                return addressExists;
            },
                cancellationToken);
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInOptional> dll)
    {

    }
}
