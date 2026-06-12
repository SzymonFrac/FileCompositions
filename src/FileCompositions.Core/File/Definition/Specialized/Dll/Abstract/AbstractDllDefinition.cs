using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;
using FileCompositions.Core.File.Init.Specialized.Dll.Policy;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using System.Reflection;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;

internal abstract class AbstractDllDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemResourceName.CreateDll(name)), IDllDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public Assembly? Assembly { get; set; }

    public required IDllInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override ValueTask InitializeAsync(CancellationToken cancellationToken) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}

