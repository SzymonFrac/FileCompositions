using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;
using FileCompositions.Extensions.Host.Schema.Resources.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Resources.ConfigureResources.Definition;

public delegate void HostSchemaResourcesConfigureResourcesDefinition(
    IHostResourceSchemaResourcesRegistrar registrar, ref IHostResourceSchemaResourcesContextProvider ctx);
