using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(inner, config);
    }



    extension(INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> inner)
    {
        public IDbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<StrictDefinition, RequiredInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> inner)
    {
        public IDbDefinitionBuilder<ExternalDefinition, RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<ExternalDefinition, RequiredInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> inner)
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<StrictDefinition, OptionalInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> inner)
    {
        public IDbDefinitionBuilder<ExternalDefinition, OptionalInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<ExternalDefinition, OptionalInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInOptional> inner)
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<StrictDefinition, OptionalInOptional, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInOptional> inner)
    {
        public IDbDefinitionBuilder<ExternalDefinition, OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<ExternalDefinition, OptionalInOptional, TDbContext>(inner, config);
    }
}
