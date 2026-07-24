using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition;

public interface IDllDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDllQuality<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal interface IDllDefinition : IFileDefinition
{
    abstract static IDllResource Convert(in IFileContext context, string name);
}