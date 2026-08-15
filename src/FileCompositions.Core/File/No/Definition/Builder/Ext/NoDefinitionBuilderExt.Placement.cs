using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoDefinitionBuilderExt
{
    extension<TOwnership>(INoDefinitionBuilder<TOwnership, RequiredInRequired> builder)
    where TOwnership : DefinitionOwnership
    {
        public INoDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public INoDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(INoDefinitionBuilder<TOwnership, OptionalInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public INoDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public INoDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(INoDefinitionBuilder<TOwnership, OptionalInOptional> builder)
        where TOwnership : DefinitionOwnership
    {

    }
}
