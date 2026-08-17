using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public INoFileDefinitionBuilder<StrictDefinition, TPlacement> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        public INoFileDefinitionBuilder<ExternalDefinition, TPlacement> External() =>
            builder.Create<ExternalDefinition, TPlacement>();

        //public INoFileDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
        //    builder.Create<TOwnership, OptionalInRequired>();
        //public INoFileDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
        //    builder.Create<TOwnership, RequiredInRequired>();
    }

    //extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> builder)
    //    where TOwnership : DefinitionOwnership
    //    where TPlacement : DefinitionPlacement
    //{
    //    public INoFileDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
    //        builder.Create<TOwnership, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
    //        builder.Create<TOwnership, RequiredInRequired>();
    //}
}
