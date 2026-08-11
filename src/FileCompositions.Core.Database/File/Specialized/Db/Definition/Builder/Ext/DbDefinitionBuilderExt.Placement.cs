using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

internal static partial class DbDefinitionBuilderExt
{
    extension<TOwnership>(DbDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<RequiredInRequired>(key);
    }

    extension<TOwnership>(DbDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInRequired>(key);
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional>> BuildInOptional(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInOptional>(key);
    }
}
