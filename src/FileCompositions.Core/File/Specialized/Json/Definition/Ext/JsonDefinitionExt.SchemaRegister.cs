using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Config;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Required>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement, TData>(JsonDefinitionConfig<TOwnership, TPlacement, Placement.RequiredInRequired, TData> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired>();
            var json = config(noBuilder);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Optional>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement, TData>(JsonDefinitionConfig<TOwnership, TPlacement, Placement.OptionalInOptional, TData> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional>();
            var json = config(noBuilder);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
