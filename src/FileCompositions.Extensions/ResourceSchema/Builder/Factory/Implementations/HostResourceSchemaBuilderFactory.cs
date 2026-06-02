using FileCompositions.Hosting.ResourceSchema.Builder.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.Builder.Factory.Implementations;

internal sealed class HostResourceSchemaBuilderFactory : IHostResourceSchemaBuilderFactory
{
    public IHostResourceSchemaBuilder Create() => new HostResourceSchemaBuilder();
}
