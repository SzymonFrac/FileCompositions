using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

internal static partial class DllDefinitionBuilderExt
{
    extension<TOwnership>(DllDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, RequiredInRequired, IDllDefinition<TOwnership, RequiredInRequired>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<RequiredInRequired>(out key);
    }

    extension<TOwnership>(DllDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInRequired, IDllDefinition<TOwnership, OptionalInRequired>> BuildInRequired(out FileDefinitionKey key) =>
            builder.Build<OptionalInRequired>(out key);
        public FileDefinitionRequestDescriptor<TOwnership, OptionalInOptional, IDllDefinition<TOwnership, OptionalInOptional>> BuildInOptional(out FileDefinitionKey key) =>
            builder.Build<OptionalInOptional>(out key);
    }
}
