using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>, IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>>,
    IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    public override ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build(DirectoryDefinitionKey directoryKey)
    {
        var key = BuildKey();

        var descriptor = Options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
