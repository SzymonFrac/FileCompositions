using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;

public interface IDbDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey);
}
