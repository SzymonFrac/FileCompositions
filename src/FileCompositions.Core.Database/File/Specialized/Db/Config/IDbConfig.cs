using FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Config;

public interface IDbConfig
{
    IDbConfig WithName(string name);

    internal DbDefinitionDescriptor<TOwnership, TPlacement> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
