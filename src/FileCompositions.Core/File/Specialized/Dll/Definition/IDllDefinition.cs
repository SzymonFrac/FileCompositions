using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Specialized.Dll.Quality;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition;

public interface IDllDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDllQuality<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement;

internal interface IDllDefinition : IFileDefinition
{
    abstract static IDllResource Convert(in IFileContext context, string name);
}