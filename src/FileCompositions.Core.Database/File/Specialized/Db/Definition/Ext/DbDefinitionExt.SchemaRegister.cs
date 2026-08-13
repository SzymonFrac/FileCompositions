using FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;
using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
    where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, RequiredInRequired, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }

        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, OptionalInRequired, RequiredDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar Define<TOwnership>(DbDefinitionConfig<TOwnership, OptionalInOptional, OptionalDefinition> config)
            where TOwnership : DefinitionOwnership
        {
            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var db = config(factory);
            var request = db.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    };
}
