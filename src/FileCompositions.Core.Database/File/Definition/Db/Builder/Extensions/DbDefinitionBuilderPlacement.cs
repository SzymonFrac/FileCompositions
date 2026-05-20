using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder.Extensions;

internal static class DbDefinitionBuilderPlacement
{
    extension<TOwnership>(IDbDefinitionBuilder<TOwnership, RequiredDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDbDefinition<TOwnership, RequiredInRequired> BuildInRequired(in IFileContext context) =>
            builder.Build<RequiredInRequired>(context);

        public IDbDefinitionDescriptor<TOwnership, RequiredInRequired> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<RequiredInRequired>();
    }

    extension<TOwnership>(IDbDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDbDefinition<TOwnership, OptionalInRequired> BuildInRequired(in IFileContext context) =>
            builder.Build<OptionalInRequired>(context);
        public IDbDefinition<TOwnership, OptionalInOptional> BuildInOptional(in IFileContext context) =>
            builder.Build<OptionalInOptional>(context);

        public IDbDefinitionDescriptor<TOwnership, OptionalInRequired> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<OptionalInRequired>();
        public IDbDefinitionDescriptor<TOwnership, OptionalInOptional> BuildDescriptorInOptional() =>
            builder.BuildDescriptor<OptionalInOptional>();
    }
}
