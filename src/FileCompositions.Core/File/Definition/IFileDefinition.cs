using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Quality;
using FileCompositions.Core.FileSystem.Addressing.Abstractions;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    FileDefinitionKey Key { get; }

    internal Task InitializeAsync(CancellationToken cancellationToken = default);
}

public interface IFileDefinition
{
    abstract static Extension Extension { get; }
}
