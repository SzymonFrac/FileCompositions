using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.ResourceSchema.File.Registrar;

public interface IResourceSchemaFileRegistrar<TInNecessity>
    where TInNecessity : Necessity
{
    internal DirectoryDefinitionKey DirectoryKey { get; }

    // does the file register not even ever need to see Directory key, cause it's already here...

    internal void Define<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>;
}
