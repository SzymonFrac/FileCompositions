using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;
using System.Reflection;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;

internal abstract class AbstractDllDefinition<TOwnership, TPlacement>(FileDefinitionKey key, IFileContext context, string name)
    : FileDefinition<TOwnership, TPlacement>(context, key, StorageResourceName.CreateDll(name)), IDllDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public Assembly? Assembly { get; set; }
}

