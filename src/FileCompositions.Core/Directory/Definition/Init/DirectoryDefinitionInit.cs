using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Directory.Definition.Init;

internal static class DirectoryDefinitionInit
{
    extension<TOwnership, TNecessity>(IDirectoryDefinitionInit<TOwnership, TNecessity> init)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public ValueTask InitializeAsync(CancellationToken cancellation = default) => init switch
        {
            IDirectoryDefinitionInit<StrictDefinition, RequiredDefinition> sr => sr.InitializeAsync(cancellation),
            IDirectoryDefinitionInit<ExternalDefinition, RequiredDefinition> er => er.InitializeAsync(cancellation),
            IDirectoryDefinitionInit<StrictDefinition, OptionalDefinition> => default,
            IDirectoryDefinitionInit<ExternalDefinition, OptionalDefinition> => default,
            _ => throw new UnreachableException()
        };
    }

    extension(IDirectoryDefinitionInit<StrictDefinition, RequiredDefinition> init)
    {
        public ValueTask InitializeAsync(CancellationToken cancellation = default) =>
            init.StorageBackend.CreateAsync(init.Address, cancellation);
    }

    extension(IDirectoryDefinitionInit<ExternalDefinition, RequiredDefinition> init)
    {
        public async ValueTask InitializeAsync(CancellationToken cancellation = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.Address, cancellation))
                throw new ExternalRequiredDirectoryMissingException("A required, external directory must exist.")
                {
                    Address = init.Address,
                    Key = init.Key
                };
        }
    }

    extension(IDirectoryDefinitionInit<StrictDefinition, OptionalDefinition> init)
    {

    }

    extension(IDirectoryDefinitionInit<ExternalDefinition, OptionalDefinition> init)
    {

    }
}
