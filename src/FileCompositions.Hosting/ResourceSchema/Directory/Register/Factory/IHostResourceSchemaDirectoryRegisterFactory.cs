using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory;

internal interface IHostResourceSchemaDirectoryRegisterFactory
{
    HostResourceSchemaRegister CreateDirectory<TOwnership, TNecessity, TFileSystem>(IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem> descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TFileSystem : class, IFileSystem;
}
