using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder;

public interface IUnspecifiedDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IUnspecifiedDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IUnspecifiedDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey);
}
