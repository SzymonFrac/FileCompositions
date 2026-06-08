using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder;

internal interface IHostResourceSchemaFileRegisterBuilder
{
    HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>;
}
