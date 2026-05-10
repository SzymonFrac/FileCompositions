using FileCompositions.Extensions.Host.Schema.Builder.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Builder.Factory.Implementations;

internal class HostResourceSchemaBuilderFactory : IHostResourceSchemaBuilderFactory
{
    public IHostResourceSchemaBuilder Create() => new HostResourceSchemaBuilder();
}
