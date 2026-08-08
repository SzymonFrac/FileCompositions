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
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var dll = config(factory);
            var descriptor = dll.BuildInRequired(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
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
            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var dll = config(factory);
            var descriptor = dll.BuildInOptional(out var key);

            registrar.Define(registrar.DirectoryKey, key, descriptor);
            return registrar;
        }
    }
}
