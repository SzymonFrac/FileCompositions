using FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;
using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement>(DbDefinitionConfig<TOwnership, TPlacement, RequiredInRequired> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, RequiredInRequired>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement>(DbDefinitionConfig<TOwnership, TPlacement, OptionalInOptional> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, OptionalInOptional>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };
}
