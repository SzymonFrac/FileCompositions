using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Abstract;

internal abstract class AbstractDirectoryLocation(IDirectoryContext context, StorageAddress address) : IDirectoryLocation
{
    public IDirectoryContext Context { get; } = context;
    public StorageAddress Address { get; } = address;

    IStorageBackend IDirectoryInterface<ExternalDefinition, RequiredDefinition>.StorageBackend => Context.StorageBackend;
    IStorageBackend IDirectoryOperator<ExternalDefinition, RequiredDefinition>.StorageBackend => Context.StorageBackend;
}