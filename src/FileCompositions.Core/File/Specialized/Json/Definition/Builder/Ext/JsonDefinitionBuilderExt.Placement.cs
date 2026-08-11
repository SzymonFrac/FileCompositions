using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

internal static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TData>(JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, RequiredInRequired, IJsonDefinition<TOwnership, RequiredInRequired, TData>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<RequiredInRequired>(key);
    }

    extension<TOwnership, TData>(JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInRequired, IJsonDefinition<TOwnership, OptionalInRequired, TData>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInRequired>(key);
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInOptional, IJsonDefinition<TOwnership, OptionalInOptional, TData>> BuildInOptional(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInOptional>(key);
    }
}