using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Directory.Register.Factory.Implementations;
using FileCompositions.Extensions.Host.Schema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Extensions.Host.Schema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.File.Registrar.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Register.Factory.Implementations;

internal class HostResourceSchemaRegisterFactory : IHostResourceSchemaRegisterFactory
{
    private readonly HostResourceSchemaDirectoryRegisterFactory _directoryFactory = new();
    public HostResourceSchemaRegister Create<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor, Action<IHostResourceSchemaFileRegistrar<TNecessity>>? registrarConfig = default)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
    {
        var fileRegisterFactory = new HostResourceSchemaFileRegisterBuilderFactory(); /*HostResourceSchemaFileRegisterBuilderFactory<TOwnership, TNecessity>();*/
        var registrar = new HostResourceSchemaFileRegistrar<TOwnership, TNecessity>(descriptor.Key, fileRegisterFactory);
        registrarConfig?.Invoke(registrar);
        var fileRegisters = registrar.Build();

        return _directoryFactory.CreateDirectory(descriptor) + fileRegisters;
    }
}
