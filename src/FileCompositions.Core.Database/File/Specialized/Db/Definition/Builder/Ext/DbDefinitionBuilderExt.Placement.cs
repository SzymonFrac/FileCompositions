using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership>(IDbDefinitionBuilder<TOwnership, RequiredInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDbDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDbDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(IDbDefinitionBuilder<TOwnership, OptionalInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDbDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDbDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(IDbDefinitionBuilder<TOwnership, OptionalInOptional> builder)
        where TOwnership : DefinitionOwnership
    {

    }
}
