using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Config;

// has .Json/.Dll too?

// exists???
public interface IFileConfig
{
    internal Func<FileDefinitionKey, IFileContext, IFileDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
