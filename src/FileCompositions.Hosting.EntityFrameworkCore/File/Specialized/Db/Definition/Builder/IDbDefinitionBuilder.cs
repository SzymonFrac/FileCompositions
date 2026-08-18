using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;

public interface IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build(DirectoryDefinitionKey directoryKey);
}
