using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, RequiredInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbOptions<TDbContext>();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext>(db);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbOptions<TDbContext>();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, OptionalInRequired, TDbContext>(db);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInOptional>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext
        {
            var db = new DbOptions<TDbContext>();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext>(db);
        }
    }
}
