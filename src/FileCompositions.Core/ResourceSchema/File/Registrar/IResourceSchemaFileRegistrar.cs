using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.ResourceSchema.File.Registrar;

public interface IResourceSchemaFileRegistrar
{
    internal IResourceSchemaFileRegistrar Store<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity>;
}
