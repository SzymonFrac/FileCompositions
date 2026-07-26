using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

internal static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public IJsonDefinition<TOwnership, RequiredInRequired, TData> BuildInRequired(in IFileContext context) =>
            builder.Build<RequiredInRequired>(context);

        public IJsonDefinitionDescriptor<TOwnership, RequiredInRequired, TData> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<RequiredInRequired>();
    }

    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public IJsonDefinition<TOwnership, OptionalInRequired, TData> BuildInRequired(in IFileContext context) =>
            builder.Build<OptionalInRequired>(context);
        public IJsonDefinition<TOwnership, OptionalInOptional, TData> BuildInOptional(in IFileContext context) =>
            builder.Build<OptionalInOptional>(context);

        public IJsonDefinitionDescriptor<TOwnership, OptionalInRequired, TData> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<OptionalInRequired>();
        public IJsonDefinitionDescriptor<TOwnership, OptionalInOptional, TData> BuildDescriptorInOptional() =>
            builder.BuildDescriptor<OptionalInOptional>();
    }
}