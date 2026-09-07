using FileCompositions.Core.Database.File.Specialized.Db.Quality;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition;

public interface IDbDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDbQuality<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement;

internal interface IDbDefinition : IFileDefinition
{
    abstract static IDbResource Convert(in IFileContext context, string name);
}
