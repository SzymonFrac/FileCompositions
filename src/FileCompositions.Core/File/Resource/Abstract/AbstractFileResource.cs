using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, FileSystemResourceName name) : IFileResource
{
    public IFileContext Context { get; } = context;
    public FileSystemResourceName Name { get; } = name;

    public FileSystemLocation GetLocation() => Context.Address.With(Name);

    IFileSystem IFileInterface<ExternalDefinition, RequiredInRequired>.StorageBackend => Context.StorageBackend;
    IFileSystem IFileOperator<ExternalDefinition, RequiredInRequired>.StorageBackend => Context.StorageBackend;
}
