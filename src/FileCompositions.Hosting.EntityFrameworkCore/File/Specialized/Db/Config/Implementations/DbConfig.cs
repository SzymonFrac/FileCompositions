using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Config.Implementations;

internal class DbConfig<TDbContext> : IDbConfig<TDbContext>
    where TDbContext : DbContext
{
    private string? name;

    public IDbConfig<TDbContext> WithName(string n)
    {
        name = n;
        return this;
    }


    public DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        if (name is null)
            throw new NullReferenceException("File must have a name.");

        return (key, context) => new DbDefinition<TOwnership, TPlacement, TDbContext>(context, key, name)
        {
            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext>()
        };
    }
}
