using FileCompositions.Core.Database.File.Definition.Db.Builder.Extensions;
using FileCompositions.Core.Database.File.Definition.Db.Builder.Factory.Implementations;
using FileCompositions.Core.Database.File.Definition.Db.Config;
using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Definition.Db.ResourceSchema.Extensions;

public static class ResourceSchemaRegistrarDbExtensions
{
    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> DefineDb<TOwnership>(DbFileDefinitionConfig<TOwnership, RequiredDefinition, TInOwnership, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<TInOwnership, RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired>, IDbDefinitionDescriptor<TOwnership, RequiredInRequired>>(descriptor);
            return registrar;
        }

        public IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> DefineDb<TOwnership>(DbFileDefinitionConfig<TOwnership, OptionalDefinition, TInOwnership, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<TInOwnership, RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired>, IDbDefinitionDescriptor<TOwnership, OptionalInRequired>>(descriptor);
            return registrar;
        }
    };

    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> DefineDb<TOwnership>(DbFileDefinitionConfig<TOwnership, OptionalDefinition, TInOwnership, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<TInOwnership, OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInOptional();

            registrar.Store<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional>, IDbDefinitionDescriptor<TOwnership, OptionalInOptional>>(descriptor);
            return registrar;
        }
    };

}
