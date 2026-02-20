using FileCompositions.Core.FileResource.Key;
using FileCompositions.Core.Schema.Settings.Registrar.To.Json;
using FileCompositions.Core.Setting.Builder.To.Json;
using FileCompositions.Core.Setting.Builder.To.Json.Implementations;
using FileCompositions.Extensions.Host.Schema.Setting.Register.Definition;
using FileCompositions.Extensions.Host.Schema.Setting.Register.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Setting.Registrar.Implementations;

internal class HostResourceSchemaJsonSettingsRegistrar<TData> : IResourceSchemaSettingsRegistrarToJson<TData>
{
    private readonly List<HostResourceSchemaSettingRegisterDefinition> _registries = [];
    //private readonly List<HostResourceSchemaSettingRegisterDefinition> _stores = [];

    public IResourceSchemaSettingsRegistrarToJson<TData> RegisterSetting<TValue>(Action<IResourceSettingBuilderToJson<TValue, TData>> config)
    {
        var builder = new ResourceSettingBuilderToJson<TValue, TData>();
        config(builder);

        var jsonRegister = new HostResourceSchemaSettingRegisterToJson<TValue, TData>(builder);
        _registries.Add(jsonRegister.Register);
        //_registries.Add(jsonRegister.RegisterStore);

        return this;
    }

    public void RegisterSettings(in IServiceCollection services, FileResourceKey key)
    {
        foreach (var register in _registries)
            register(in services, key);
    }
    //public void RegisterSettingStores(in IServiceCollection other, FileResourceKey key)
    //{
    //    foreach (var register in _stores)
    //        register(in other, key);
    //}
}
