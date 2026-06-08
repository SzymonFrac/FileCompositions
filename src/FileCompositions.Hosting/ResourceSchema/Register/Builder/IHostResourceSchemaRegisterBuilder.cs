using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Register.Builder;
using FileCompositions.Hosting.ResourceSchema.Register.Config;

namespace FileCompositions.Hosting.ResourceSchema.Register.Builder;

public interface IHostResourceSchemaRegisterBuilder : IResourceSchemaRegisterBuilder
{
    IHostResourceSchemaRegisterBuilder Store<TOwnership, TNecessity>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;

    internal HostResourceSchemaRegister? Build();
}