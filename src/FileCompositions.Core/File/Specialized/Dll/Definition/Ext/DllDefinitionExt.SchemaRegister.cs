using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Dll.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DllDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var dllBuilder = config(builder);
            //var descriptor = dllBuilder.BuildDescriptorInRequired();

            //registrar.Store<TOwnership, RequiredInRequired, IDllDefinition<TOwnership, RequiredInRequired>, IDllDefinitionDescriptor<TOwnership, RequiredInRequired>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var dll = config(factory);
            var descriptor = dll.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DllDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            //var dllBuilder = config(builder);
            //var descriptor = dllBuilder.BuildDescriptorInRequired();

            //registrar.Store<TOwnership, OptionalInRequired, IDllDefinition<TOwnership, OptionalInRequired>, IDllDefinitionDescriptor<TOwnership, OptionalInRequired>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var dll = config(factory);
            var descriptor = dll.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            //var builder = new DllDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            //var dllBuilder = config(builder);
            //var descriptor = dllBuilder.BuildDescriptorInOptional();

            //registrar.Store<TOwnership, OptionalInOptional, IDllDefinition<TOwnership, OptionalInOptional>, IDllDefinitionDescriptor<TOwnership, OptionalInOptional>>(descriptor);
            //return registrar;

            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var dll = config(factory);
            var descriptor = dll.BuildInOptional(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    }
}
