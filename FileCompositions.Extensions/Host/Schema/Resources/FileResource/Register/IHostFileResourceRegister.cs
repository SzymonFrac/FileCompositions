using FileCompositions.Core.Schema.Resources.FileResource.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register;

public interface IHostFileResourceRegister : IResourceSchemaFileResourceRegister
{
    void Register(in IServiceCollection services);
    void RegisterSettings(in IServiceCollection settingsServices);
}
