using FileCompositions.Extensions.Host.Schema.Builder.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Builder.Factory.Implementations;

internal class HostResourceSchemaBuilderFactory : IHostResourceSchemaBuilderFactory
{
    public IHostResourceSchemaBuilder Create(IHostResourceSchemaFileResourceRegistrar fileRegistrar) =>
        new HostResourceSchemaBuilder(fileRegistrar);
}
