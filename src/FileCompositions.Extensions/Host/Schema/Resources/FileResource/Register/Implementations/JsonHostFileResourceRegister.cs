using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.FileResource.Key;
using FileCompositions.Core.FileResource.Specialized.Json;
using FileCompositions.Core.FileResource.Specialized.Json.Descriptor;
using FileCompositions.Extensions.Host.Schema.Setting.Registrar.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Implementations;

internal class JsonHostFileResourceRegister<TData>(FileResourceKey key, IJsonFileResourceDescriptor<TData> descriptor, HostResourceSchemaJsonSettingsRegistrar<TData>? settings = default) : IHostFileResourceRegister
{
    private readonly FileResourceKey _key = key;
    private readonly IJsonFileResourceDescriptor<TData> _descriptor = descriptor;
    private readonly HostResourceSchemaJsonSettingsRegistrar<TData>? settings = settings;

    public void Register(in IServiceCollection services)
    {
        services.AddKeyedSingleton<IJsonFileResource<TData>>(_key.Value, (sp, key) =>
        {
            var schema = sp.GetRequiredService<IHostResourceSchema>();
            var directory = schema.GetDirectoryLocation(_descriptor.DirectoryLocationKey)
                ?? throw new NullReferenceException($"There is no directory registered under given key {_key}.");
            
            var fileResource = _descriptor.Activate(directory);
            return fileResource;
        });

        settings?.RegisterSettings(in services, _key);
    }
    public void RegisterSettings(in IServiceCollection settingsServices)
    {
        settingsServices.AddKeyedSingleton<IJsonFileResource<TData>>(_key.Value, (sp, key) =>
        {
            var directory = sp.GetRequiredKeyedService<IDirectoryLocation>(_descriptor.DirectoryLocationKey.Value);
            var fileResource = _descriptor.Activate(directory);
            return fileResource;
        });

        settings?.RegisterSettings(in settingsServices, _key);
    }
}
