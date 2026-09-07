using FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;
using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Required>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement>(DbDefinitionConfig<TOwnership, TPlacement, Placement.RequiredInRequired> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<Necessity.Optional>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement>(DbDefinitionConfig<TOwnership, TPlacement, Placement.OptionalInOptional> config)
            where TOwnership : Ownership
            where TPlacement : Placement
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };
}
