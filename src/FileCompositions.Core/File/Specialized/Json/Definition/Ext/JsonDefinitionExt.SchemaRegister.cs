using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Factory.Implementation;
using FileCompositions.Core.File.Specialized.Json.Definition.Config;
using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;
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
        public TResourceSchemaFileRegistrar DefineJson<TOwnership, TData>(JsonDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, RequiredInRequired, IJsonDefinition<TOwnership, RequiredInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, RequiredInRequired, TData>>(descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar DefineJson<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, OptionalInRequired, IJsonDefinition<TOwnership, OptionalInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInRequired, TData>>(descriptor);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineJson<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInOptional();

            registrar.Store<TOwnership, OptionalInOptional, IJsonDefinition<TOwnership, OptionalInOptional, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInOptional, TData>>(descriptor);
            return registrar;
        }
    }
}
