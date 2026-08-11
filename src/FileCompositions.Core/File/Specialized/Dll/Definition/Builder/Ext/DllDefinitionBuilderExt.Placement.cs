using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

internal static partial class DllDefinitionBuilderExt
{
    extension<TOwnership>(DllDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, RequiredInRequired, IDllDefinition<TOwnership, RequiredInRequired>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<RequiredInRequired>(key);
    }

    extension<TOwnership>(DllDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInRequired, IDllDefinition<TOwnership, OptionalInRequired>> BuildInRequired(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInRequired>(key);
        public ResourceSchemaFileRegisterRequest<TOwnership, OptionalInOptional, IDllDefinition<TOwnership, OptionalInOptional>> BuildInOptional(DirectoryDefinitionKey key) =>
            builder.Build<OptionalInOptional>(key);
    }
}
