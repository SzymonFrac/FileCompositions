using FileCompositions.Core.Setting;
using FileCompositions.Core.Setting.Descriptor;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Setting.Descriptor.Register;

//internal class HostResourceSchemaSettingDescriptorRegister<TValue>(IResourceSettingDescriptor<TValue> descriptor)
//{
//    private readonly IResourceSettingDescriptor<TValue> _descriptor = descriptor;
//    void Register(in IServiceCollection services) =>
//        services.AddKeyedSingleton<IResourceSettingDescriptor<TValue>>(_descriptor.Key.Value, sp =>
//        {
//            var setting = sp.GetRequiredKeyedService<IResourceSetting<TValue>>(_descriptor.Key.Value);
//            var defined = _descriptor.Activate(setting.Store);
//            return defined;
//        });
//}
