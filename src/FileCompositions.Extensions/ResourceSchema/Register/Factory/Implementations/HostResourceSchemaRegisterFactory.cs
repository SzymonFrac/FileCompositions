using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.Register.Factory.Implementations;

internal sealed class HostResourceSchemaRegisterFactory : IHostResourceSchemaRegisterFactory
{
    private readonly HostResourceSchemaDirectoryRegisterFactory _directoryFactory = new();
    public HostResourceSchemaRegister Create<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor, Action<IHostResourceSchemaFileRegistrar<TNecessity>>? registrarConfig = default)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
    {
        var fileRegisterFactory = new HostResourceSchemaFileRegisterBuilderFactory();
        var registrar = new HostResourceSchemaFileRegistrar<TOwnership, TNecessity>(descriptor.Key, fileRegisterFactory);
        registrarConfig?.Invoke(registrar);
        var fileRegisters = registrar.Build();

        return _directoryFactory.CreateDirectory(descriptor) + fileRegisters;
    }
}
