using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TDbContext>(IDbDefinitionBuilder<TOwnership, RequiredInRequired, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public IDbDefinitionBuilder<TOwnership, OptionalInRequired, TDbContext> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDbDefinitionBuilder<TOwnership, RequiredInRequired, TDbContext> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership, TDbContext>(IDbDefinitionBuilder<TOwnership, OptionalInRequired, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public IDbDefinitionBuilder<TOwnership, OptionalInRequired, TDbContext> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDbDefinitionBuilder<TOwnership, RequiredInRequired, TDbContext> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership, TDbContext>(IDbDefinitionBuilder<TOwnership, OptionalInOptional, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {

    }
}
