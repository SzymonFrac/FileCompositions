using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Core.ResourceSchema.Directory.Registrar.Factory;
using FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory;
using FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Factory.Implementations;

internal sealed class HostResourceSchemaDirectoryRegistrarFactory : IHostResourceSchemaDirectoryRegistrarFactory
{
    public IDirectoryDefinitionBuilderFactory DirectoryBuilderFactory { get; init; } = new DirectoryDefinitionBuilderFactory();
    public IHostResourceSchemaDirectoryRegisterFactory DirectoryRegisterFactory { get; init; } = new HostResourceSchemaDirectoryRegisterFactory();
    public IHostResourceSchemaFileRegistrarFactory FileRegistrarFactory { get; init; } = new HostResourceSchemaFileRegistrarFactory();

    public IHostResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required> Create() =>
        new HostResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required>()
        {
            DirectoryBuilderFactory = DirectoryBuilderFactory,
            DirectoryRegisterFactory = DirectoryRegisterFactory,
            FileRegistrarFactory = FileRegistrarFactory
        };
    public IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : Ownership
        where TNecessity : Necessity =>
            new HostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>()
            {
                DirectoryBuilderFactory = DirectoryBuilderFactory,
                DirectoryRegisterFactory = DirectoryRegisterFactory,
                FileRegistrarFactory = FileRegistrarFactory
            };

    IResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required> IResourceSchemaDirectoryRegistrarFactory.Create() =>
        Create();
    IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> IResourceSchemaDirectoryRegistrarFactory.Create<TOwnership, TNecessity>() =>
        Create<TOwnership, TNecessity>();
}
