using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Hosting.ResourceSchema.Builder;
using FileCompositions.Hosting.ResourceSchema.Builder.Factory.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileCompositions.Hosting.Host.Builder.Extensions;

public static class HostBuilderFileComposition
{
    extension(IHostBuilder builder)
    {
        public IHostBuilder ConfigureFileResources(Action<IHostResourceSchemaBuilder> config) =>
            builder.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<LocalStorageBackend>();

                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create();
                config(builder);

                var schema = builder.Build(in services);
                schema.Init(in services);
            });
    }
}
