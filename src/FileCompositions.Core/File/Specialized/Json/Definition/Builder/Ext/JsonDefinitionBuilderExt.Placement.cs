using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, RequiredInRequired, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public IJsonDefinitionBuilder<TOwnership, OptionalInRequired, TData> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IJsonDefinitionBuilder<TOwnership, RequiredInRequired, TData> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, OptionalInRequired, TData> builder)
        where TOwnership : DefinitionOwnership
    {
        public IJsonDefinitionBuilder<TOwnership, OptionalInRequired, TData> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IJsonDefinitionBuilder<TOwnership, RequiredInRequired, TData> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, OptionalInOptional, TData> builder)
        where TOwnership : DefinitionOwnership
    {

    }
}