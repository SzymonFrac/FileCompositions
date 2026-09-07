using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder;

public interface IDllDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDllDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey);
}
