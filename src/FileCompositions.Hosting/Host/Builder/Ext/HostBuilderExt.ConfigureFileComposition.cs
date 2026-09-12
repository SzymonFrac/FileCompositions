using FileCompositions.Hosting.ResourceSchema.Builder;
using FileCompositions.Hosting.ResourceSchema.Builder.Factory.Implementations;
using Microsoft.Extensions.Hosting;

namespace FileCompositions.Hosting.Host.Builder.Ext;

public static partial class HostBuilderExt
{
    extension(IHostBuilder builder)
    {
        public IHostBuilder ConfigureFileComposition(Action<IHostResourceSchemaBuilder> config) =>
            builder.ConfigureServices((ctx, services) =>
            {
                var builderFactory = new HostResourceSchemaBuilderFactory();
                var builder = builderFactory.Create();
                config(builder);

                var schema = builder
                    .Build()
                    .Init(in services);
            });
    }
}
