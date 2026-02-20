using FileCompositions.Core.FileResource.Key;
using FileCompositions.Core.FileResource.Specialized.Json;
using FileCompositions.Core.Setting;
using FileCompositions.Core.Setting.Builder.To.Json.Implementations;
using FileCompositions.Core.Setting.Store;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace FileCompositions.Extensions.Host.Schema.Setting.Register.Implementations;

internal class HostResourceSchemaSettingRegisterToJson<TValue, TData>(ResourceSettingBuilderToJson<TValue, TData> builder) : IHostResourceSchemaSettingRegister<TValue>
{
    private readonly ResourceSettingBuilderToJson<TValue, TData> _builder = builder;
    public void Register(in IServiceCollection services, FileResourceKey key) =>
        services.AddKeyedSingleton<IResourceSetting<TValue>>(_builder.Key.Value, (sp, k) =>
        {
            var fileInterface = sp.GetRequiredKeyedService<IJsonFileResource<TData>>(key.Value);
            var setting = _builder.Build(fileInterface);
            return setting;
        });

    //public void RegisterStore(in IServiceCollection other, FileResourceKey key) =>
    //    other.AddKeyedSingleton<IResourceSettingStore<TValue>>(_builder.Key.Value, (sp, k) =>
    //    {
    //        var fileInterface = sp.GetRequiredKeyedService<IJsonFileResource<TData>>(key.Value);
    //        var setting = _builder.Build(fileInterface);
    //        return setting.Store;
    //    });
}
