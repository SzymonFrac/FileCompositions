using FileCompositions.Core.Setting.Builder.To.Json;

namespace FileCompositions.Core.Schema.Settings.Registrar.To.Json;

public interface IResourceSchemaSettingsRegistrarToJson<TData>
{
    IResourceSchemaSettingsRegistrarToJson<TData> RegisterSetting<TValue>(Action<IResourceSettingBuilderToJson<TValue, TData>> config);
}
