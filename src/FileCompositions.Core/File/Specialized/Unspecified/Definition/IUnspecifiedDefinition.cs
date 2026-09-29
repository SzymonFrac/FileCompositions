using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Specialized.Unspecified.Quality;
using FileCompositions.Core.File.Specialized.Unspecified.Resource;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition;

public interface IUnspecifiedDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IUnspecifiedQuality<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement;

internal interface IUnspecifiedDefinition : IFileDefinition
{
    abstract static IUnspecifiedResource Convert(in IFileContext context, string name);
}
