using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Custom.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Custom.Builder.Extensions;

public static class CustomDefinitionBuilderPlacement
{
    extension<TOwnership>(ICustomDefinitionBuilder<TOwnership, RequiredDefinition, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        internal TDefinition BuildInRequired<TDefinition>(in IFileContext context, ICustomDefinition<TOwnership, RequiredInRequired, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, RequiredInRequired, TDefinition> =>
                builder.Build(in context, definition);
        public ICustomDefinitionDescriptor<TOwnership, RequiredInRequired, TDefinition> BuildDescriptorInRequired<TDefinition>(ICustomDefinition<TOwnership, RequiredInRequired, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, RequiredInRequired, TDefinition> =>
                builder.BuildDescriptor(definition);
    }

    extension<TOwnership>(ICustomDefinitionBuilder<TOwnership, OptionalDefinition, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        internal TDefinition BuildInRequired<TDefinition>(in IFileContext context, ICustomDefinition<TOwnership, OptionalInRequired, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, OptionalInRequired, TDefinition> =>
                builder.Build(context, definition);
        public ICustomDefinitionDescriptor<TOwnership, OptionalInRequired, TDefinition> BuildDescriptorInRequired<TDefinition>(ICustomDefinition<TOwnership, OptionalInRequired, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, OptionalInRequired, TDefinition> =>
                builder.BuildDescriptor(definition);
    }

    extension<TOwnership>(ICustomDefinitionBuilder<TOwnership, OptionalDefinition, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        internal TDefinition BuildInOptional<TDefinition>(in IFileContext context, ICustomDefinition<TOwnership, OptionalInOptional, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, OptionalInOptional, TDefinition> =>
                builder.Build(context, definition);
        public ICustomDefinitionDescriptor<TOwnership, OptionalInOptional, TDefinition> BuildDescriptorInOptional<TDefinition>(ICustomDefinition<TOwnership, OptionalInOptional, TDefinition> definition)
            where TDefinition : ICustomDefinition<TOwnership, OptionalInOptional, TDefinition> =>
                builder.BuildDescriptor(definition);
    }
}
