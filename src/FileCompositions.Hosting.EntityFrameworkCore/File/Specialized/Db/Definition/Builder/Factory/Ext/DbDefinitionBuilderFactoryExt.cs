using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory.Ext;

public static partial class DbDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public IDbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbOptions<TDbContext>();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext>(db);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbOptions<TDbContext>();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext>(db);
            return builder;
        }
    }
}
