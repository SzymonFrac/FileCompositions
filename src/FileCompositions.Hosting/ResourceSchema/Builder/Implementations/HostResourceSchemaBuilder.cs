using FileCompositions.Core.ResourceSchema.Builder;
using FileCompositions.Core.ResourceSchema.FileSystem.Registrar;
using FileCompositions.Hosting.ResourceSchema.FileSystem.Registrar.Implementations;
using FileCompositions.Hosting.ResourceSchema.Implementation;
using FileCompositions.Hosting.ResourceSchema.Register.Builder;
using FileCompositions.Hosting.ResourceSchema.Register.Builder.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.Builder.Implementations;

internal sealed class HostResourceSchemaBuilder : IHostResourceSchemaBuilder
{
    private readonly HostResourceSchemaFileSystemRegistrar _storageBackendRegistrar = new();
    private readonly HostResourceSchemaRegisterBuilder _registerBuilder = new();

    public IHostResourceSchemaBuilder ConfigureFileSystems(Action<IResourceSchemaFileSystemRegistrar> config)
    {
        config(_storageBackendRegistrar);
        return this;
    }
    public IHostResourceSchemaBuilder ConfigureDefinitions(Action<IHostResourceSchemaRegisterBuilder> config)
    {
        config(_registerBuilder);
        return this;
    }

    public IHostResourceSchema Build()
    {
        var directoryRegistries = _storageBackendRegistrar.Build() +
            _registerBuilder.Build();

        var schema = new HostResourceSchema(directoryRegistries);
        return schema;
    }

    IResourceSchemaBuilder IResourceSchemaBuilder.ConfigureFileSystems(Action<IResourceSchemaFileSystemRegistrar> config) =>
        ConfigureFileSystems(config);
}
