using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;

public interface IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>>
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build(DirectoryDefinitionKey directoryKey);
}
