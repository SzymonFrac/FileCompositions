using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.Directory.Register.Factory;

internal interface IHostResourceSchemaDirectoryRegisterFactory
{
    HostResourceSchemaRegister CreateDirectory<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;
}
