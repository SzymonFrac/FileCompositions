using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Config;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<RequiredDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInRequired<TOwnership, TPlacement, TData>(JsonDefinitionConfig<TOwnership, TPlacement, RequiredInRequired, TData> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, RequiredInRequired>();
            var json = config(noBuilder);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }

    extension<TResourceSchemaFileRegistrar>(TResourceSchemaFileRegistrar registrar)
        where TResourceSchemaFileRegistrar : IResourceSchemaFileRegistrar<OptionalDefinition>
    {
        public TResourceSchemaFileRegistrar DefineInOptional<TOwnership, TPlacement, TData>(JsonDefinitionConfig<TOwnership, TPlacement, OptionalInOptional, TData> config)
            where TOwnership : DefinitionOwnership
            where TPlacement : DefinitionPlacement
        {
            var noBuilder = new NoFileDefinitionBuilder<StrictDefinition, OptionalInOptional>();
            var json = config(noBuilder);
            var request = json.Build(registrar.DirectoryKey);

            registrar.Define(request);
            return registrar;
        }
    }
}
