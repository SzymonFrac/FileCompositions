using FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.ResourceSchema.Builder;
using FileCompositions.Core.ResourceSchema.File.Definition.Registrar;
using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Implementations;
using FileCompositions.Hosting.ResourceSchema.Implementation;
using FileCompositions.Hosting.ResourceSchema.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.StorageBackend.Registrar.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Builder.Implementations;

internal sealed class HostResourceSchemaBuilder : IHostResourceSchemaBuilder
{
    private readonly HostResourceSchemaStorageBackendRegistrar _storageBackendRegistrar = new();
    private readonly HostResourceSchemaDirectoryRegistrar _directoryRegistrar =
        new(new DirectoryDefinitionBuilderFactory(), new HostResourceSchemaRegisterBuilderFactory());

    public IHostResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config)
    {
        config(_storageBackendRegistrar);
        return this;
    }

    public IHostResourceSchemaBuilder ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config)
    {
        throw new NotImplementedException();
    }

    public IHostResourceSchemaBuilder ConfigureRegistries(Action<IHostResourceSchemaDirectoryRegistrar> config)
    {
        config(_directoryRegistrar);
        return this;
    }

    public IHostResourceSchema Build(in IServiceCollection services)
    {
        var directoryRegistries = _storageBackendRegistrar.Build() +
            _directoryRegistrar.Build();

        var schema = new HostResourceSchema(directoryRegistries);
        return schema;
    }

    IResourceSchemaBuilder IResourceSchemaBuilder.ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config) =>
        ConfigureStorageBackends(config);
    IResourceSchemaBuilder IResourceSchemaBuilder.ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config) =>
        ConfigureDefinitions(config);
}
