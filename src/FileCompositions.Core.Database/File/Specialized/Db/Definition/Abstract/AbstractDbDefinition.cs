using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy;
using FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Name;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemFilename.CreateDb(name)), IDbDefinition<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    public required IDbInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override Task InitializeAsync(CancellationToken cancellationToken = default) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}
