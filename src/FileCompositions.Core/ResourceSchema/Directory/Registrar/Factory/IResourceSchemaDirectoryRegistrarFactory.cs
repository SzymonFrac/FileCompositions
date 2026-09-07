using FileCompositions.Core.Quality;

namespace FileCompositions.Core.ResourceSchema.Directory.Registrar.Factory;

internal interface IResourceSchemaDirectoryRegistrarFactory
{
    IResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required> Create();
    IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : Ownership
        where TNecessity : Necessity;
}
