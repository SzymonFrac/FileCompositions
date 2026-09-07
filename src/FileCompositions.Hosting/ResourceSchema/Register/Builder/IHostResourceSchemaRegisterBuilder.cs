using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.Register.Builder;
using FileCompositions.Hosting.ResourceSchema.Register.Config;

namespace FileCompositions.Hosting.ResourceSchema.Register.Builder;

public interface IHostResourceSchemaRegisterBuilder : IResourceSchemaRegisterBuilder
{
    IHostResourceSchemaRegisterBuilder Store<TOwnership, TNecessity>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity> config)
        where TOwnership : Ownership
        where TNecessity : Necessity;

    internal HostResourceSchemaRegister? Build();
}