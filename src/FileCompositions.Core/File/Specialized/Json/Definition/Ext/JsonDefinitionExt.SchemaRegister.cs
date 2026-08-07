using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Json.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
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
            //var builder = new JsonDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInRequired(out var key);

            //registrar.Store<TOwnership, RequiredInRequired, IJsonDefinition<TOwnership, RequiredInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, RequiredInRequired, TData>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory();
            var json = config(factory);
            var descriptor = json.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar DefineJson<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new JsonDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInRequired();

            //registrar.Store<TOwnership, OptionalInRequired, IJsonDefinition<TOwnership, OptionalInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInRequired, TData>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory();
            var json = config(factory);
            var descriptor = json.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineJson<TOwnership, TData>(JsonDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new JsonDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInOptional();

            //registrar.Store<TOwnership, OptionalInOptional, IJsonDefinition<TOwnership, OptionalInOptional, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInOptional, TData>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory();
            var json = config(factory);
            var descriptor = json.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    }
}
