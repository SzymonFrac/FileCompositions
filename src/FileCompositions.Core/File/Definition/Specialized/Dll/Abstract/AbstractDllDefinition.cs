using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;
using FileCompositions.Core.File.Definition.Specialized.Dll.Init.Policy;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Resource.Name;
using System.Reflection;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;

internal abstract class AbstractDllDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, StorageResourceName.CreateDll(name)), IDllDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public Assembly? Assembly { get; set; }

    public required IDllDefinitionInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override ValueTask InitializeAsync(CancellationToken cancellationToken) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);

    IStorageBackend IFileInterface<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IStorageBackend IFileDefinitionInit<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IStorageBackend IFileOperator<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
}

