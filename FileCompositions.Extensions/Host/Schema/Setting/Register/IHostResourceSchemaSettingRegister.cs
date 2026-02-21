using FileCompositions.Core.FileResource.Key;
using FileCompositions.Core.Schema.Settings.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Setting.Register;

internal interface IHostResourceSchemaSettingRegister<TValue> : IResourceSchemaSettingRegister<TValue>
{
    void Register(in IServiceCollection services, FileResourceKey key);
    //void RegisterStore(in IServiceCollection other, FileResourceKey key);
}
