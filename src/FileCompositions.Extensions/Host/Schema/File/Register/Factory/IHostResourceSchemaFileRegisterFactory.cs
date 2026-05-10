using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Factory;

internal interface IHostResourceSchemaFileRegisterFactory<TDirectory>
    where TDirectory : IDirectoryLocation
{
    HostResourceSchemaRegister CreateFile<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity>;
}
