using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal IJsonDefinitionBuilder<TOwnership, TPlacement, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<TOwnership, TPlacement, TData>(inner, config);
    }



    extension(INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> inner)
    {
        public IJsonDefinitionBuilder<StrictDefinition, RequiredInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<StrictDefinition, RequiredInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> inner)
    {
        public IJsonDefinitionBuilder<ExternalDefinition, RequiredInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<ExternalDefinition, RequiredInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> inner)
    {
        public IJsonDefinitionBuilder<StrictDefinition, OptionalInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<StrictDefinition, OptionalInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> inner)
    {
        public IJsonDefinitionBuilder<ExternalDefinition, OptionalInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<ExternalDefinition, OptionalInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInOptional> inner)
    {
        public IJsonDefinitionBuilder<StrictDefinition, OptionalInOptional, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<StrictDefinition, OptionalInOptional, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInOptional> inner)
    {
        public IJsonDefinitionBuilder<ExternalDefinition, OptionalInOptional, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<ExternalDefinition, OptionalInOptional, TData>(inner, config);
    }
}
