using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.Database.File.Definition.Db.Init.Policy;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Database.File.Definition.Db.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, StorageResourceName.CreateDb(name)), IDbDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public required IDbDefinitionInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override ValueTask InitializeAsync(CancellationToken cancellationToken = default) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);

    IStorageBackend IFileInterface<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IStorageBackend IFileDefinitionInit<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IStorageBackend IFileOperator<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
}
