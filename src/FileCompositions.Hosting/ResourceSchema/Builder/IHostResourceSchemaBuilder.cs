using FileCompositions.Core.ResourceSchema.Builder;
using FileCompositions.Core.ResourceSchema.FileSystem.Registrar;
using FileCompositions.Hosting.ResourceSchema.Register.Builder;

namespace FileCompositions.Hosting.ResourceSchema.Builder;

public interface IHostResourceSchemaBuilder : IResourceSchemaBuilder
{
    new IHostResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaFileSystemRegistrar> config);
    IHostResourceSchemaBuilder ConfigureDefinitions(Action<IHostResourceSchemaRegisterBuilder> config);
    internal IHostResourceSchema Build();
}
