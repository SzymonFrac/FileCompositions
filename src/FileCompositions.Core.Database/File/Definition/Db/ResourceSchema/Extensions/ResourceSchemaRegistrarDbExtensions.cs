using FileCompositions.Core.Database.File.Definition.Db.Builder.Factory.Implementations;
using FileCompositions.Core.Database.File.Definition.Db.Config;
using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Definition.Db.ResourceSchema.Extensions;

public static class ResourceSchemaRegistrarDbExtensions
{
    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, OptionalDefinition> DefineDb<TOwnership>(DbFileDefinitionConfig<TOwnership, OptionalDefinition, TInOwnership, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<TInOwnership, OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptor();

            registrar.Store<TOwnership, OptionalDefinition, IDbDefinition<TOwnership, OptionalDefinition>, IDbDefinitionDescriptor<TOwnership, OptionalDefinition>>(descriptor);
            return registrar;
        }
    };

    extension<TInOwnership>(IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> registrar)
        where TInOwnership : DefinitionOwnership
    {
        public IResourceSchemaFileRegistrar<TInOwnership, RequiredDefinition> DefineDb<TOwnership, TNecessity>(DbFileDefinitionConfig<TOwnership, TNecessity, TInOwnership, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
            where TNecessity : DefinitionNecessity
        {
            var builder = new DbDefinitionBuilderFactory<TInOwnership, RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptor();

            registrar.Store<TOwnership, TNecessity, IDbDefinition<TOwnership, TNecessity>, IDbDefinitionDescriptor<TOwnership, TNecessity>>(descriptor);
            return registrar;
        }
    };
}
