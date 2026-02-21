using FileCompositions.Core.FileResource.Key;
using FileCompositions.Core.FileResource.Specialized.Db;
using FileCompositions.Core.FileResource.Specialized.Db.Descriptor;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Implementations;

internal class DbHostFileResourceRegister(FileResourceKey key, IDbFileResourceDescriptor descriptor) : IHostFileResourceRegister
{
    private readonly FileResourceKey _key = key;
    private readonly IDbFileResourceDescriptor _descriptor = descriptor;
    public void Register(in IServiceCollection services)
    {
        services.AddKeyedSingleton<IDbFileResource>(_key.Value, (sp, key) =>
        {
            var schema = sp.GetRequiredService<IHostResourceSchema>();
            var directory = schema.GetDirectoryLocation(_descriptor.DirectoryLocationKey)
                ?? throw new NullReferenceException($"There is no directory registered under given key {_key}.");

            var fileResource = _descriptor.Activate(directory);
            return fileResource;
        });
    }

    public void RegisterSettings(in IServiceCollection settingsServices) => Register(in settingsServices);
}
