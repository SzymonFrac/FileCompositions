using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.Schema.Settings.Registrar.To.Json;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Definition;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Mux;
using FileCompositions.Extensions.Host.Schema.Setting.Registrar.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Specialized.Json.Extensions;

//mux...
public static class HostResourceSchemaJsonRegisters
{
    extension(IHostResourceSchemaFileResourceRegisterMux mux)
    {
        public HostFileResourceRegisterDefinition AsJson<TData>(Action<IJsonResourceBuilder<TData>> config) =>
            new((directoryKey, fileKey, baseConfig) =>
            {
                var baseBuilder = new FileResourceBuilder();
                baseConfig(baseBuilder);

                var jsonBuilder = baseBuilder.ToJson<TData>(JsonFileResourceSpecializationContext.Default);
                config(jsonBuilder);
                var jsonDescriptor = jsonBuilder.BuildDescriptor(directoryKey);

                var jsonRegister = new JsonHostFileResourceRegister<TData>(fileKey, jsonDescriptor);
                return jsonRegister;
            });
        public HostFileResourceRegisterDefinition AsJson<TData>(Action<IJsonResourceBuilder<TData>> builder, Action<IResourceSchemaSettingsRegistrarToJson<TData>/*IResourceSchemaSettingsRegistrar<IJsonFileResourceFileInterface<TData>>*/> settings)
        {
            return new((directoryKey, fileKey, baseConfig) =>
            {
                var settingsRegistrar = new HostResourceSchemaJsonSettingsRegistrar<TData>();
                settings(settingsRegistrar);

                var baseBuilder = new FileResourceBuilder();
                baseConfig(baseBuilder);

                var jsonBuilder = baseBuilder.ToJson<TData>(JsonFileResourceSpecializationContext.Default);
                builder(jsonBuilder);
                var jsonDescriptor = jsonBuilder.BuildDescriptor(directoryKey);

                var jsonRegister = new JsonHostFileResourceRegister<TData>(fileKey, jsonDescriptor, settingsRegistrar);
                return jsonRegister;
            });
        }
    }
}
