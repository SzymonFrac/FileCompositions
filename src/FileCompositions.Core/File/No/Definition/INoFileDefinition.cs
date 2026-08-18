using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition;

public interface INoFileDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;
