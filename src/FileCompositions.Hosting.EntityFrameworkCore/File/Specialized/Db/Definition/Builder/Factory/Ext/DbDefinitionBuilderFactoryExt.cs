using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Config;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Config.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory.Ext;

public static partial class DbDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public DbDefinitionBuilder<StrictDefinition, RequiredDefinition, TDbContext> Db<TDbContext>(Action<IDbConfig<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbConfig<TDbContext>();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, RequiredDefinition, TDbContext>(db);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public DbDefinitionBuilder<StrictDefinition, OptionalDefinition, TDbContext> Db<TDbContext>(Action<IDbConfig<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbConfig<TDbContext>();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, OptionalDefinition, TDbContext>(db);
            return builder;
        }
    }
}
