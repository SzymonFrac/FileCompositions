using FileCompositions.Core.File.Definition.Custom.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Definition.Custom.Extensions;

public static class ResourceSchemaRegisterCustom
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar DefineCustom<TOwnership, TDefinition>(CustomDefinitionConfig<TOwnership, RequiredInRequired, RequiredDefinition, TDefinition> config)
            where TOwnership : DefinitionOwnership
            where TDefinition : class, ICustomDefinition<TOwnership, RequiredInRequired, TDefinition>
        {
            throw new NotImplementedException();

            //var builder = new CustomDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var descriptor = config(builder);
            
            //registrar.Store<TOwnership, RequiredInRequired, TDefinition, ICustomDefinitionDescriptor<TOwnership, RequiredInRequired, TDefinition>>(descriptor);
            //return registrar;
        }

        public TResourceSchemaFileRegistrar DefineCustom<TOwnership, TDefinition>(CustomDefinitionConfig<TOwnership, OptionalInRequired, RequiredDefinition, TDefinition> config)
            where TOwnership : DefinitionOwnership
            where TDefinition : class, ICustomDefinition<TOwnership, OptionalInRequired, TDefinition>
        {
            throw new NotImplementedException();

            //var builder = new CustomDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var descriptor = config(builder);

            //registrar.Store<TOwnership, OptionalInRequired, TDefinition, ICustomDefinitionDescriptor<TOwnership, OptionalInRequired, TDefinition>>(descriptor);
            //return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineCustom<TOwnership, TDefinition>(CustomDefinitionConfig<TOwnership, OptionalInOptional, OptionalDefinition, TDefinition> config)
            where TOwnership : DefinitionOwnership
            where TDefinition : class, ICustomDefinition<TOwnership, OptionalInOptional, TDefinition>
        {
            throw new NotImplementedException();

            //var builder = new CustomDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            //var descriptor = config(builder);

            //registrar.Store<TOwnership, OptionalInOptional, TDefinition, ICustomDefinitionDescriptor<TOwnership, OptionalInOptional, TDefinition>>(descriptor);
            //return registrar;
        }
    }
}
