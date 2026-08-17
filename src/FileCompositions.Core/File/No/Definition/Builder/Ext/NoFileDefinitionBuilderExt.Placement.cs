using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    //extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> builder)
    //    where TOwnership : DefinitionOwnership
    //    where TPlacement : DefinitionPlacement
    //{
    //    public INoFileDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
    //        builder.Create<TOwnership, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
    //        builder.Create<TOwnership, RequiredInRequired>();
    //}

    extension(INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> builder)
    {
        public INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
            builder.Create<StrictDefinition, OptionalInRequired>();
        public INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
            builder.Create<StrictDefinition, RequiredInRequired>();
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> builder)
    {
        public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
            builder.Create<ExternalDefinition, OptionalInRequired>();
        public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
            builder.Create<ExternalDefinition, RequiredInRequired>();
    }

    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> builder)
    {
        public INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
            builder.Create<StrictDefinition, OptionalInRequired>();
        public INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
            builder.Create<StrictDefinition, RequiredInRequired>();
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> builder)
    {
        public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
            builder.Create<ExternalDefinition, OptionalInRequired>();
        public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
            builder.Create<ExternalDefinition, RequiredInRequired>();
    }

    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, OptionalInOptional> builder)
        where TOwnership : DefinitionOwnership
    {
        
    }

    //extension(INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> builder)
    //{
    //    public INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
    //        builder.Create<StrictDefinition, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
    //        builder.Create<StrictDefinition, RequiredInRequired>();
    //}

    //extension(INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> builder)
    //{
    //    public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
    //        builder.Create<ExternalDefinition, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
    //        builder.Create<ExternalDefinition, RequiredInRequired>();
    //}

    //extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> builder)
    //{
    //    public INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
    //        builder.Create<StrictDefinition, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
    //        builder.Create<StrictDefinition, RequiredInRequired>();
    //}

    //extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> builder)
    //{
    //    public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
    //        builder.Create<ExternalDefinition, OptionalInRequired>();
    //    public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
    //        builder.Create<ExternalDefinition, RequiredInRequired>();
    //}

    //extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, OptionalInOptional> builder)
    //    where TOwnership : DefinitionOwnership
    //{

    //}
}
