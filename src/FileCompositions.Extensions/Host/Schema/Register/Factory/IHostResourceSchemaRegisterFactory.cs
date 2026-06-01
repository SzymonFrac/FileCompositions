using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.File.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Register.Factory;

internal interface IHostResourceSchemaRegisterFactory
{
    HostResourceSchemaRegister Create<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor, Action<IHostResourceSchemaFileRegistrar<TNecessity>>? registrarConfig = default)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;
}
