using FileCompositions.Core.File.Definition.Builder.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Definition.Specialized.Json.Config;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;

namespace FileCompositions.Core.File.Definition.Specialized.Json.ResourceSchema.Extensions;

public static class ResourceSchemaRegistrarJsonExtensions
{
    extension(IResourceSchemaFileRegistrar registrar)
    {
        public IResourceSchemaFileRegistrar Store<TOwnership, TNecessity, TData>(JsonFileDefinitionConfig<TOwnership, TNecessity, TData> config)
            where TOwnership : DefinitionOwnership
            where TNecessity : DefinitionNecessity
        {
            var builder = new FileDefinitionBuilder();
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptor();

            return registrar.Store<TOwnership, TNecessity, JsonDefinition<TOwnership, TNecessity, TData>, IJsonDefinitionDescriptor<TOwnership, TNecessity, TData>>(descriptor);
        }
    };
}