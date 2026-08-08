using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;
using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
    where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInRequired();

            //registrar.Store<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired>, IDbDefinitionDescriptor<TOwnership, RequiredInRequired>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var descriptor = db.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInRequired();

            //registrar.Store<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired>, IDbDefinitionDescriptor<TOwnership, OptionalInRequired>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var descriptor = db.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    };

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DbDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            //var jsonBuilder = config(builder);
            //var descriptor = jsonBuilder.BuildDescriptorInOptional();

            //registrar.Store<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional>, IDbDefinitionDescriptor<TOwnership, OptionalInOptional>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var db = config(factory);
            var descriptor = db.BuildInOptional(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    };
}
