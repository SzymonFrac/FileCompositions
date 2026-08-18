using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, RequiredInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public INoFileDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public INoFileDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, OptionalInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public INoFileDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public INoFileDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, OptionalInOptional> builder)
        where TOwnership : DefinitionOwnership
    {
        
    }
}
