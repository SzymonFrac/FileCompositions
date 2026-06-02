using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Hosting.ResourceSchema.Register;
using FileCompositions.Hosting.ResourceSchema.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.Register.Config;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Implementations;

internal sealed class HostResourceSchemaDirectoryRegistrar(IDirectoryDefinitionBuilderFactory builderFactory, IHostResourceSchemaRegisterBuilderFactory registerBuilderFactory)
    : IHostResourceSchemaDirectoryRegistrar
{
    private readonly IDirectoryDefinitionBuilderFactory _builderFactory = builderFactory;
    private readonly IHostResourceSchemaRegisterBuilderFactory _registerBuilderFactory = registerBuilderFactory;
    
    private HostResourceSchemaRegister? register;

    public IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity, TBackend>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity, TBackend> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
    {
        var baseBuilder = _registerBuilderFactory.CreateDefault(_builderFactory);
        var builder = config(baseBuilder);
        register += builder.Build();

        return this;
    }
    public IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        var baseBuilder = _registerBuilderFactory.CreateDefault(_builderFactory);
        var builder = config(baseBuilder);
        register += builder.Build();

        return this;
    }

    public HostResourceSchemaRegister? Build() => register;
}
