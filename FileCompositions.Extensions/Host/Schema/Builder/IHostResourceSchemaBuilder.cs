using FileCompositions.Core.Schema.Builder;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Builder;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;
using FileCompositions.Extensions.Host.Schema.Resources.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Builder;

public interface IHostResourceSchemaBuilder : IResourceSchemaBuilder
{
    IHostResourceSchemaBuilder ConfigureRoots(Action<IHostResourceSchemaResourcesContextBuilder> config);
    IHostResourceSchemaBuilder ConfigureResources(Action<IHostResourceSchemaResourcesRegistrar, IHostResourceSchemaResourcesContextProvider> config);
    internal IHostResourceSchema Build(ref IServiceProvider sp);
}
