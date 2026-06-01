using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Extensions.Host.Schema.Builder;
using FileCompositions.Extensions.Host.Schema.Builder.Factory.Implementations;
using FileCompositions.Extensions.Host.Schema.Initializer.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileCompositions.Extensions.Host;

public static class HostFileCompositions
{
    extension(IHostBuilder builder)
    {
        public IHostBuilder ConfigureFileResources(Action<IHostResourceSchemaBuilder> config) =>
            builder.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<LocalStorageBackend>();
                //services.AddSingleton<IFileLocationResolverFactory, AssemblyFileLocationResolverFactory>();

                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create();
                config(builder);

                var schema = builder.Build(in services);
                schema.Init(in services);
            });
    }
}
