using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Extension.Some;
using FileCompositions.Core.File.Quality;
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
    abstract static SomeFileExtension Extension { get; }
}
