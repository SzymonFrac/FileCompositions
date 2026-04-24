using FileCompositions.Core.ResourceSchema.File.Definition.Registrar;
using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;

namespace FileCompositions.Core.ResourceSchema.Builder;

public interface IResourceSchemaBuilder
{
    IResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config);
    IResourceSchemaBuilder ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config);
}
