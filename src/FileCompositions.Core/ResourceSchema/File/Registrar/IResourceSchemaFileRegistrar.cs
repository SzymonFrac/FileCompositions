using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.ResourceSchema.File.Registrar;

public interface IResourceSchemaFileRegistrar<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    internal DirectoryDefinitionKey DirectoryKey { get; }

    //internal void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
    //    where TOwnership : DefinitionOwnership
    //    where TPlacement : DefinitionPlacement
    //    where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
    //    where TDescriptor : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>;

    // does the file register not even ever need to see Directory key, cause it's already here...

    internal void Define<TOwnership, TPlacement, TDefinition>(DirectoryDefinitionKey directoryKey, FileDefinitionKey fileKey, FileDefinitionRequestDescriptor<TOwnership, TPlacement, TDefinition> descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>;
}
