using FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Config.Implementations;

internal sealed class DbConfig : IDbConfig
{
    private string? name;

    public IDbConfig WithName(string n)
    {
        name = n;
        return this;
    }


    public DbDefinitionDescriptor<TOwnership, TPlacement> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        if (name is null)
            throw new NullReferenceException("File must have a name.");

        return (key, context) => new DbDefinition<TOwnership, TPlacement>(context, key, name)
        {
            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
        };
    }
}
