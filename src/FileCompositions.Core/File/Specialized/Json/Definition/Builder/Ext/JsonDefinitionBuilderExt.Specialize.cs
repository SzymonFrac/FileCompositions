using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.File.Specialized.Json.Options.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TDefinition, TBuilder>(TBuilder builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, RequiredInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder>
    {
        public IJsonDefinitionBuilder<StrictDefinition, RequiredInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config)
        {
            var json = new JsonOptions<TData>();
            config(json);

            return new JsonDefinitionBuilder<StrictDefinition, RequiredInRequired, TData>(json);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder>
    {
        public IJsonDefinitionBuilder<StrictDefinition, OptionalInRequired, TData> Json<TData>(Action<IJsonOptions<TData>> config)
        {
            var json = new JsonOptions<TData>();
            config(json);

            return new JsonDefinitionBuilder<StrictDefinition, OptionalInRequired, TData>(json);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInOptional>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder>
    {
        public IJsonDefinitionBuilder<StrictDefinition, OptionalInOptional, TData> Json<TData>(Action<IJsonOptions<TData>> config)
        {
            var json = new JsonOptions<TData>();
            config(json);

            return new JsonDefinitionBuilder<StrictDefinition, OptionalInOptional, TData>(json);
        }
    }
}
