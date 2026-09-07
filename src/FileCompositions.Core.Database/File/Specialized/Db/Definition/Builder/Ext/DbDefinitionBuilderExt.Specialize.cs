using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        public IDbDefinitionBuilder<TOwnership, TPlacement> Db(Action<IDbOptions> config) =>
            new DbDefinitionBuilder<TOwnership, TPlacement>(inner, config);
    }
}
