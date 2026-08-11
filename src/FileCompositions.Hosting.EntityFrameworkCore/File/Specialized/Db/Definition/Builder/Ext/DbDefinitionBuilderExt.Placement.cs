using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

internal static class DbDefinitionBuilderExt
{
    extension<TOwnership, TDbContext>(DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired, TDbContext>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<RequiredInRequired>(key);
    }

    extension<TOwnership, TDbContext>(DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired, TDbContext>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInRequired>(key);
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional, TDbContext>> BuildInOptional(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInOptional>(key);
    }
}
