using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder;

internal interface IHostResourceSchemaFileRegisterBuilder
{
    HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>;
}
