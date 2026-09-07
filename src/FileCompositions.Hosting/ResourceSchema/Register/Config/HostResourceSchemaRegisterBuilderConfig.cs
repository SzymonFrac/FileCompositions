using FileCompositions.Core.Quality;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar;

namespace FileCompositions.Hosting.ResourceSchema.Register.Config;

public delegate IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity>(IHostResourceSchemaDirectoryRegistrar<Ownership.Internal, Necessity.Required> config)
    where TOwnership : Ownership
    where TNecessity : Necessity;
