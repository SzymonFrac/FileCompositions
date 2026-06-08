using FileCompositions.Core.FileSystem.Specialized.Local.Implementations;
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
                services.AddSingleton<LocalFileSystem>();

                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create();
                config(builder);

                var schema = builder
                    .Build()
                    .Init(in services);
            });
    }
}
