using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Init;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource;

public interface IFileResource : IFileInterface<ExternalDefinition, RequiredInRequired>,
    IFileInit<ExternalDefinition, RequiredInRequired>,
    IFileOperator<ExternalDefinition, RequiredInRequired>
{
    internal IFileContext Context { get; }

    FileSystemResourceName Name { get; }
}