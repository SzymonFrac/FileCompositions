using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, Placement.RequiredInRequired> builder)
        where TOwnership : Ownership
    {
        public INoFileDefinitionBuilder<TOwnership, Placement.OptionalInRequired> Optional() =>
            builder.Create<TOwnership, Placement.OptionalInRequired>();
        public INoFileDefinitionBuilder<TOwnership, Placement.RequiredInRequired> Required() =>
            builder.Create<TOwnership, Placement.RequiredInRequired>();
    }

    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, Placement.OptionalInRequired> builder)
        where TOwnership : Ownership
    {
        public INoFileDefinitionBuilder<TOwnership, Placement.OptionalInRequired> Optional() =>
            builder.Create<TOwnership, Placement.OptionalInRequired>();
        public INoFileDefinitionBuilder<TOwnership, Placement.RequiredInRequired> Required() =>
            builder.Create<TOwnership, Placement.RequiredInRequired>();
    }

    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, Placement.OptionalInOptional> builder)
        where TOwnership : Ownership
    {
        
    }
}
