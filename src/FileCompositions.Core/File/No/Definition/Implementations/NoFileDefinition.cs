using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Implementations;

internal sealed class NoFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, default), INoFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public override Task InitializeAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
