using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Quality;
using FileCompositions.Core.FileSystem.Resource.Extension;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    FileDefinitionKey Key { get; }
}

public interface IFileDefinition
{
    abstract static FileSystemResourceExtension Extension { get; }
}
