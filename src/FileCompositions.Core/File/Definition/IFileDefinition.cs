using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.FileSystem.Resource.Extension;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>,
    IFileDefinitionInit<TOwnership, TPlacement>,
    IFileOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal IFileContext Context { get; }

    FileSystemResourceName Name { get; }
}

public interface IFileDefinition
{
    abstract static FileSystemResourceExtension Extension { get; }
}
