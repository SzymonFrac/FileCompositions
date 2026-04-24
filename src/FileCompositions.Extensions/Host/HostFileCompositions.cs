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

                //Obsolete
                //var fileRegistrar = new HostResourceSchemaFileResourceRegistrar(ref services);

                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create(fileRegistrar);
                config(builder);

                var schema = builder.Build(in services);
                
                // initAndBuild
                schema.Init(ref services);

                //services.AddSingleton<IHostResourceSchema>(sp => builder.Build(ref sp));
            });

            return builder;
        }
    }
}
