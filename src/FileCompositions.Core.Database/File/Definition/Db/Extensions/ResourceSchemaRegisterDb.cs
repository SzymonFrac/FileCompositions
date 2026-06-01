using FileCompositions.Core.Database.File.Definition.Db.Builder.Extensions;
using FileCompositions.Core.Database.File.Definition.Db.Builder.Factory.Implementations;
using FileCompositions.Core.Database.File.Definition.Db.Config;
using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Definition.Db.Extensions;

public static class ResourceSchemaRegisterDb
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar DefineDb<TOwnership>(DbDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired>, IDbDefinitionDescriptor<TOwnership, RequiredInRequired>>(descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar DefineDb<TOwnership>(DbDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            registrar.Store<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired>, IDbDefinitionDescriptor<TOwnership, OptionalInRequired>>(descriptor);
            return registrar;
        }
    };

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineDb<TOwnership>(DbDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var builder = new DbDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInOptional();

            registrar.Store<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional>, IDbDefinitionDescriptor<TOwnership, OptionalInOptional>>(descriptor);
            return registrar;
        }
    };

}
