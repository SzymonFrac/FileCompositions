using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, RequiredInRequired, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var dll = config(factory);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, OptionalInRequired, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var dll = config(factory);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DllDefinitionConfig<TOwnership, OptionalInOptional, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var dll = config(factory);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
