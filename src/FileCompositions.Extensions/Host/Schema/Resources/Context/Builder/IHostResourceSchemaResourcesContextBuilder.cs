using FileCompositions.Core.Setting.Builder;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context.Builder;

public interface IHostResourceSchemaResourcesContextBuilder
{
    IHostResourceSchemaResourcesContextBuilder Define(string name, StorageAddress address);
    IHostResourceSchemaResourcesContextBuilder Define(Action<IResourceSettingBuilder<string>> config);
    internal void UpdateProvider(ref IHostResourceSchemaResourcesContextProvider provider);
}
