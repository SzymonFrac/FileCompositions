using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Extensions.Host.Schema;
using FileCompositions.Extensions.Host.Schema.Builder;
using FileCompositions.Extensions.Host.Schema.Builder.Factory.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar.Implementations;
using FileCompositions.Extensions.Host.StorageBackend.Registrar.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileCompositions.Extensions.Host;

public static class HostFileCompositions
{
    extension(IHostBuilder builder)
    {
        public IHostBuilder ConfigureFileResources(Action<IHostResourceSchemaBuilder> config)
        {
            builder.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<LocalDiskStorageBackend>();

                IServiceCollection settingServices = new ServiceCollection();
                settingServices.AddSingleton<LocalDiskStorageBackend>();

                var storageBackendRegistrar = new HostStorageBackendRegistrar(ref services, ref settingServices);
                var fileRegistrar = new HostResourceSchemaFileResourceRegistrar(ref services, ref settingServices);

                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create(storageBackendRegistrar, fileRegistrar, settingServices);
                config(builder);

                services.AddSingleton<IHostResourceSchema>(sp => builder.Build(ref sp));
            });

            return builder;
        }
    }
}
