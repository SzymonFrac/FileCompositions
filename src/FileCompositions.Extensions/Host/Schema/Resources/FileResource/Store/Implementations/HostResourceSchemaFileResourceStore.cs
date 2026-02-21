using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Builder;
using FileCompositions.Core.FileResource.Key;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Definition;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Mux;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Implementations;

internal class HostResourceSchemaFileResourceStore : IHostResourceSchemaFileResourceStore, IHostResourceSchemaFileResourceRegisterMux
{
    private DirectoryLocationKey directoryKey;
    private FileResourceKey fileKey;
    private Action<IFileResourceBuilder>? baseConfig;
    private HostFileResourceRegisterDefinition? registerDefinition;

    public IHostResourceSchemaFileResourceStoreUseKey To(DirectoryLocationKey key)
    {
        directoryKey = key;
        return this;
    }
    public IHostResourceSchemaFileResourceStoreFile UseKey(FileResourceKey key)
    {
        fileKey = key;
        return this;
    }
    public IHostResourceSchemaFileResourceStoreRegister File(Action<IFileResourceBuilder> config)
    {
        baseConfig = config;
        return this;
    }
    public void Register(Func<IHostResourceSchemaFileResourceRegisterMux, HostFileResourceRegisterDefinition> config) =>
        registerDefinition = config(this);

    public IHostFileResourceRegister BuildRegister()
    {
        if (directoryKey.Equals(default))
            throw new ArgumentNullException(nameof(directoryKey));
        if (fileKey.Equals(default))
            throw new ArgumentNullException(nameof(fileKey));
        if (baseConfig is null)
            throw new ArgumentNullException(nameof(baseConfig));
        if (registerDefinition is null)
            throw new ArgumentNullException(nameof(registerDefinition));


        return registerDefinition(directoryKey, fileKey, baseConfig);
    }
}
