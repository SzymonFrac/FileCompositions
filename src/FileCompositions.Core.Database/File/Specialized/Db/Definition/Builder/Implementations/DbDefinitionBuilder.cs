using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

internal sealed class DbDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDbOptions> config)
    : AbstractDbDefinitionBuilder<TOwnership, TPlacement>(inner, config)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
