using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, StorageResourceName name) : IFileResource
{
    public IFileContext Context { get; } = context;
    public StorageResourceName Name { get; } = name;

    public StorageLocation GetLocation() => Context.Address.With(Name);

    IStorageBackend IFileInterface<ExternalDefinition, RequiredInRequired>.StorageBackend => Context.StorageBackend;
    IStorageBackend IFileOperator<ExternalDefinition, RequiredInRequired>.StorageBackend => Context.StorageBackend;
}
