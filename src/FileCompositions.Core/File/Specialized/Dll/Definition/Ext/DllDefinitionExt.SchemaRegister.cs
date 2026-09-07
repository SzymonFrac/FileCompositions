using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Config;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Required>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement>(DllDefinitionConfig<TOwnership, TPlacement, Placement.RequiredInRequired> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired>();
            var dll = config(noBuilder);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Optional>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement>(DllDefinitionConfig<TOwnership, TPlacement, Placement.OptionalInOptional> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional>();
            var dll = config(noBuilder);
            var request = dll.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
