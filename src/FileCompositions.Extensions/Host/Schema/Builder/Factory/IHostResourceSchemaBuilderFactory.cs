using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Builder.Factory;

internal interface IHostResourceSchemaBuilderFactory
{
    IHostResourceSchemaBuilder Create(IHostResourceSchemaFileResourceRegistrar fileRegistrar);
}
