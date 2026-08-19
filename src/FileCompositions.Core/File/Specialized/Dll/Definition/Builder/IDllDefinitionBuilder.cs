using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder;

public interface IDllDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDllDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey);
}
