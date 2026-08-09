using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.File.Specialized.Json.Config;
using FileCompositions.Core.File.Specialized.Json.Config.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Factory.Ext;

public static partial class JsonDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public JsonDefinitionBuilder<StrictDefinition, RequiredDefinition, TData> Json<TData>(Action<IJsonConfig<TData>> config)
        {
            var json = new JsonConfig<TData>();
            config(json);
            
            var builder = new JsonDefinitionBuilder<StrictDefinition, RequiredDefinition, TData>(json);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public JsonDefinitionBuilder<StrictDefinition, OptionalDefinition, TData> Json<TData>(Action<IJsonConfig<TData>> config)
        {
            var json = new JsonConfig<TData>();
            config(json);

            var builder = new JsonDefinitionBuilder<StrictDefinition, OptionalDefinition, TData>(json);
            return builder;
        }
    }
}
