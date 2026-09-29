using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Config;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Ext;

public static partial class UnspecifiedDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Required>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement>(UnspecifiedDefinitionConfig<TOwnership, TPlacement, Placement.RequiredInRequired> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired>();
            var unspecified = config(noBuilder);
            var request = unspecified.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Optional>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement>(UnspecifiedDefinitionConfig<TOwnership, TPlacement, Placement.OptionalInOptional> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional>();
            var unspecified = config(noBuilder);
            var request = unspecified.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
