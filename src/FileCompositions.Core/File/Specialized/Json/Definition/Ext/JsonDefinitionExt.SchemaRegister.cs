using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership, TData>(JsonDefinitionConfig<TOwnership, RequiredInRequired, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var json = config(factory);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalInRequired, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var json = config(factory);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalInOptional, OptionalDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var json = config(factory);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
