using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

internal static class DbDefinitionBuilderExt
{
    extension<TOwnership, TDbContext>(DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public FileDefinitionRequestDescriptor<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired, TDbContext>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<RequiredInRequired>(out key);
    }

    extension<TOwnership, TDbContext>(DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired, TDbContext>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<OptionalInRequired>(out key);
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional, TDbContext>> BuildInOptional(out FileDefinitionKey key) =>
            builder.Build<OptionalInOptional>(out key);
    }
}
