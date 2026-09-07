using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        internal IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(inner, config);
    }



    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired> inner)
    {
        public IDbDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.RequiredInRequired> inner)
    {
        public IDbDefinitionBuilder<Ownership.External, Placement.RequiredInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.External, Placement.RequiredInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired> inner)
    {
        public IDbDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.OptionalInRequired> inner)
    {
        public IDbDefinitionBuilder<Ownership.External, Placement.OptionalInRequired, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.External, Placement.OptionalInRequired, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional> inner)
    {
        public IDbDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional, TDbContext>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.OptionalInOptional> inner)
    {
        public IDbDefinitionBuilder<Ownership.External, Placement.OptionalInOptional, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<Ownership.External, Placement.OptionalInOptional, TDbContext>(inner, config);
    }
}
