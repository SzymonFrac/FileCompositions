using FileCompositions.Core.File.Definition.Specialized.Json.Builder.Extensions;
using FileCompositions.Core.File.Definition.Specialized.Json.Builder.Factory.Implementation;
using FileCompositions.Core.File.Definition.Specialized.Json.Config;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Definition.Specialized.Json.ResourceSchema.Extensions;

public static class ResourceSchemaRegistrarJsonExtensions
{
    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> DefineJson<TOwnership, TData>(JsonFileDefinitionConfig<TOwnership, RequiredDefinition, TInOwnership, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<TInOwnership, RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, RequiredInRequired, IJsonDefinition<TOwnership, RequiredInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, RequiredInRequired, TData>>(descriptor);
            return registrar;
        }

        public IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> DefineJson<TOwnership, TData>(JsonFileDefinitionConfig<TOwnership, OptionalDefinition, TInOwnership, RequiredDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<TInOwnership, RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, OptionalInRequired, IJsonDefinition<TOwnership, OptionalInRequired, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInRequired, TData>>(descriptor);
            return registrar;
        }
    }

    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> DefineJson<TOwnership, TData>(JsonFileDefinitionConfig<TOwnership, OptionalDefinition, TInOwnership, OptionalDefinition, TData> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new JsonDefinitionBuilderFactory<TInOwnership, OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInOptional();

            registrar.Store<TOwnership, OptionalInOptional, IJsonDefinition<TOwnership, OptionalInOptional, TData>, IJsonDefinitionDescriptor<TOwnership, OptionalInOptional, TData>>(descriptor);
            return registrar;
        }
    }
}