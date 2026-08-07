using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

internal static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TData>(JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, RequiredInRequired, IJsonDefinition<TOwnership, RequiredInRequired, TData>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<RequiredInRequired>(out key);
    }

    extension<TOwnership, TData>(JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInRequired, IJsonDefinition<TOwnership, OptionalInRequired, TData>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<OptionalInRequired>(out key);
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInOptional, IJsonDefinition<TOwnership, OptionalInOptional, TData>> BuildInOptional(out FileDefinitionKey key) =>
            builder.Build<OptionalInOptional>(out key);
    }
}