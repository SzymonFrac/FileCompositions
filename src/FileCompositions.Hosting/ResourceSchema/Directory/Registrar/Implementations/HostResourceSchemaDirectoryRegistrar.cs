using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory;
using FileCompositions.Hosting.ResourceSchema.Directory.Register.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Implementations;

internal sealed class HostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> : IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    private HostResourceSchemaRegister? register;
    private readonly DirectoryDefinitionKey? key;

    public IDirectoryDefinitionBuilderFactory DirectoryBuilderFactory { get; init; } = new DirectoryDefinitionBuilderFactory();
    public IHostResourceSchemaDirectoryRegisterFactory DirectoryRegisterFactory { get; init; } = new HostResourceSchemaDirectoryRegisterFactory();
    public IHostResourceSchemaFileRegistrarFactory FileRegistrarFactory { get; init; } = new HostResourceSchemaFileRegistrarFactory();

    public HostResourceSchemaDirectoryRegistrar() { }
    private HostResourceSchemaDirectoryRegistrar(HostResourceSchemaRegister r, DirectoryDefinitionKey k) => (register, key) = (r, k);

    public IHostResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity, TDefFileSystem>(DirectoryDefinitionConfig<TDefOwnership, TDefNecessity, TDefFileSystem> config)
        where TDefOwnership : Ownership
        where TDefNecessity : Necessity
        where TDefFileSystem : class, IFileSystem
    {
        var builder = config(DirectoryBuilderFactory);
        var descriptor = builder.BuildDescriptor();

        var register = DirectoryRegisterFactory.CreateDirectory(descriptor);

        return new HostResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity>(register, descriptor.Key);
    }

    public IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config)
    {
        if (key is null)
            throw new ArgumentNullException(nameof(key));

        var registrar = FileRegistrarFactory.Create<TOwnership, TNecessity>(key);
        config(registrar);
        var fileRegisters = registrar.Build();

        register += fileRegisters;

        return this;
    }

    public HostResourceSchemaRegister? Build() => register;

    IResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity> IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>.Define<TDefOwnership, TDefNecessity, TDefFileSystem>(DirectoryDefinitionConfig<TDefOwnership, TDefNecessity, TDefFileSystem> config) =>
        Define(config);
}
