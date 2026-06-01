using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Directory.Definition.Init;

internal static class DirectoryDefinitionInit
{
    extension<TOwnership, TNecessity>(IDirectoryDefinitionInit<TOwnership, TNecessity> @operator)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public ValueTask InitializeAsync(CancellationToken cancellation = default) => @operator switch
        {
            IDirectoryDefinitionInit<StrictDefinition, RequiredDefinition> sr => sr.InitializeAsync(cancellation),
            IDirectoryDefinitionInit<ExternalDefinition, RequiredDefinition> er => er.InitializeAsync(cancellation),
            IDirectoryDefinitionInit<StrictDefinition, OptionalDefinition> => default,
            IDirectoryDefinitionInit<ExternalDefinition, OptionalDefinition> => default,
            _ => throw new UnreachableException()
        };
    }

    extension(IDirectoryDefinitionInit<StrictDefinition, RequiredDefinition> @operator)
    {
        public ValueTask InitializeAsync(CancellationToken cancellation = default) =>
            @operator.StorageBackend.CreateAsync(@operator.Address, cancellation);
    }

    extension(IDirectoryDefinitionInit<ExternalDefinition, RequiredDefinition> @operator)
    {
        public async ValueTask InitializeAsync(CancellationToken cancellation = default)
        {
            if (!await @operator.StorageBackend.ExistsAsync(@operator.Address, cancellation))
                throw new DirectoryNotFoundException("A required, external directory must exist.");
        }
    }

    extension(IDirectoryDefinitionInit<StrictDefinition, OptionalDefinition> @operator)
    {

    }

    extension(IDirectoryDefinitionInit<ExternalDefinition, OptionalDefinition> @operator)
    {

    }
}
