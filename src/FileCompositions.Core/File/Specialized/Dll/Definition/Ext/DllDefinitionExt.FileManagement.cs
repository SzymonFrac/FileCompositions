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
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            dll.RequestFileSystemAsync(async (fs, ct) =>
            {
                if (!await fs.ExistsAsync(dll.GetLocation(), ct).ConfigureAwait(false))
                {
                    await using var stream = await fs.OpenCreateAsync(dll.GetLocation(), ct).ConfigureAwait(false);

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
            dll.RequestFileSystemAsync(async (fs, ct) =>
            {
                var addressExists = await fs.ExistsAsync(dll.GetLocation().Address, ct).ConfigureAwait(false);
                if (addressExists)
                {
                    await using var stream = await fs.OpenCreateAsync(dll.GetLocation(), ct).ConfigureAwait(false);

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
