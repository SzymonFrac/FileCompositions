using FileCompositions.Core.File.Context;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Extensions;

internal static class DbDefinitionBuilderPlacement
{
    extension<TOwnership, TDbContext>(IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public IDbDefinition<TOwnership, RequiredInRequired, TDbContext> BuildInRequired(in IFileContext context) =>
            builder.Build<RequiredInRequired>(context);

        public IDbDefinitionDescriptor<TOwnership, RequiredInRequired, TDbContext> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<RequiredInRequired>();
    }

    extension<TOwnership, TDbContext>(IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TDbContext : DbContext
    {
        public IDbDefinition<TOwnership, OptionalInRequired, TDbContext> BuildInRequired(in IFileContext context) =>
            builder.Build<OptionalInRequired>(context);
        public IDbDefinition<TOwnership, OptionalInOptional, TDbContext> BuildInOptional(in IFileContext context) =>
            builder.Build<OptionalInOptional>(context);

        public IDbDefinitionDescriptor<TOwnership, OptionalInRequired, TDbContext> BuildDescriptorInRequired() =>
            builder.BuildDescriptor<OptionalInRequired>();
        public IDbDefinitionDescriptor<TOwnership, OptionalInOptional, TDbContext> BuildDescriptorInOptional() =>
            builder.BuildDescriptor<OptionalInOptional>();
    }
}
