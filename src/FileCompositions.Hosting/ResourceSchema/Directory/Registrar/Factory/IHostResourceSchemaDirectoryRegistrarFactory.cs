using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.Directory.Registrar.Factory;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Factory;

internal interface IHostResourceSchemaDirectoryRegistrarFactory : IResourceSchemaDirectoryRegistrarFactory
{
    new IHostResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required> Create();
    new IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : Ownership
        where TNecessity : Necessity;
}
