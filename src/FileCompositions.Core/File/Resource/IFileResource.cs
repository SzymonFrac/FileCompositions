using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource : IFileInterface<ExternalDefinition, RequiredInRequired>,
    IFileOperator<ExternalDefinition, RequiredInRequired>
{
    internal IFileContext Context { get; }

    StorageResourceName Name { get; }
}