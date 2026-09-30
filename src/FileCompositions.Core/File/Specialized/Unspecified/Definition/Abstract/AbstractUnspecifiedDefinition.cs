using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Init.Policy;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Abstract;

internal abstract class AbstractUnspecifiedDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, Filename.CreateUnspecified(name)), IUnspecifiedDefinition<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    public required IUnspecifiedInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override Task InitializeAsync(CancellationToken cancellationToken) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}
