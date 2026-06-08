using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Factory;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register.Config;

namespace FileCompositions.Hosting.ResourceSchema.Register.Builder.Implementations;

internal sealed class HostResourceSchemaRegisterBuilder
    : IHostResourceSchemaRegisterBuilder
{
    private HostResourceSchemaRegister? register;
    
    public IHostResourceSchemaDirectoryRegistrarFactory DirectoryRegistrarFactory { get; init; } = new HostResourceSchemaDirectoryRegistrarFactory();

    public IHostResourceSchemaRegisterBuilder Store<TOwnership, TNecessity>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        var baseBuilder = DirectoryRegistrarFactory.Create();
        var builder = config(baseBuilder);
        register += builder.Build();

        return this;
    }

    public HostResourceSchemaRegister? Build() => register;
}
