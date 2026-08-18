using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement>(DllDefinitionConfig<TOwnership, TPlacement, RequiredInRequired> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, RequiredInRequired>();
            var dll = config(noBuilder);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement>(DllDefinitionConfig<TOwnership, TPlacement, OptionalInOptional> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, OptionalInOptional>();
            var dll = config(noBuilder);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
