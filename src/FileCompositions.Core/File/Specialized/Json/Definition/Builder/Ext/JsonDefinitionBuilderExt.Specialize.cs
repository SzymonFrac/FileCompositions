using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        internal IJsonDefinitionBuilder<TOwnership, TPlacement, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<TOwnership, TPlacement, TData>(inner, config);
    }



    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired> inner)
    {
        public IJsonDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.RequiredInRequired> inner)
    {
        public IJsonDefinitionBuilder<Ownership.External, Placement.RequiredInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.External, Placement.RequiredInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired> inner)
    {
        public IJsonDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.Internal, Placement.OptionalInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.OptionalInRequired> inner)
    {
        public IJsonDefinitionBuilder<Ownership.External, Placement.OptionalInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.External, Placement.OptionalInRequired, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional> inner)
    {
        public IJsonDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional, TData>(inner, config);
    }

    extension(INoFileDefinitionBuilder<Ownership.External, Placement.OptionalInOptional> inner)
    {
        public IJsonDefinitionBuilder<Ownership.External, Placement.OptionalInOptional, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<Ownership.External, Placement.OptionalInOptional, TData>(inner, config);
    }
}
