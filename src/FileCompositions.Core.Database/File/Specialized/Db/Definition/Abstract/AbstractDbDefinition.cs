using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy;
using FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileName.CreateDb(name)), IDbDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public required IDbInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override Task InitializeAsync(CancellationToken cancellationToken = default) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}
