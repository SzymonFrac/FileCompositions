using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

internal static partial class DbDefinitionBuilderExt
{
    extension<TOwnership>(DbDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<RequiredInRequired>(out key);
    }

    extension<TOwnership>(DbDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<OptionalInRequired>(out key);
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional>> BuildInOptional(out FileDefinitionKey key) =>
            builder.Build<OptionalInOptional>(out key);
    }
}
