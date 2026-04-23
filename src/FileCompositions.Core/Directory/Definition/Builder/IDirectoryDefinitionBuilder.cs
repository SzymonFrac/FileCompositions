using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Definition.Builder;

public interface IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> : IDirectoryDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend
{
    new IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> WithKey(DirectoryDefinitionKey key);
    new IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> WithAddress(StorageAddress address);
    new IDirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend;

    new IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TBackend> External();
    new IDirectoryDefinitionBuilder<StrictDefinition, TNecessity, TBackend> Strict();
    new IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TBackend> Required();
    new IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend> Optional();

    internal IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> BuildDescriptor();
}

public interface IDirectoryDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IDirectoryDefinitionBuilder<TOwnership, TNecessity> WithKey(DirectoryDefinitionKey key);
    IDirectoryDefinitionBuilder<TOwnership, TNecessity> WithAddress(StorageAddress address);
    IDirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend;

    IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity> External();
    IDirectoryDefinitionBuilder<StrictDefinition, TNecessity> Strict();
    IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition> Required();
    IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition> Optional();

    internal IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context);
}
