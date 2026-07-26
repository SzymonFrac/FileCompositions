using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

internal static partial class DllDefinitionBuilderExt
{
    extension<TOwnership>(IDllDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDllDefinition<TOwnership, RequiredInRequired> BuildInRequired(in IFileContext context) =>
            builder.Build<RequiredInRequired>(context);

        public IDllDefinitionDescriptor<TOwnership, RequiredInRequired> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<RequiredInRequired>();
    }

    extension<TOwnership>(IDllDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDllDefinition<TOwnership, OptionalInRequired> BuildInRequired(in IFileContext context) =>
            builder.Build<OptionalInRequired>(context);
        public IDllDefinition<TOwnership, OptionalInOptional> BuildInOptional(in IFileContext context) =>
            builder.Build<OptionalInOptional>(context);

        public IDllDefinitionDescriptor<TOwnership, OptionalInRequired> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<OptionalInRequired>();
        public IDllDefinitionDescriptor<TOwnership, OptionalInOptional> BuildDescriptorInOptional() =>
            builder.BuildDescriptor<OptionalInOptional>();
    }
}
