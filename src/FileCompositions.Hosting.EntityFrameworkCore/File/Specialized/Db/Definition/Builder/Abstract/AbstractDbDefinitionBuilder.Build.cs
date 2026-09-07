using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> : IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDbContext : DbContext
{
    public ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build(DirectoryDefinitionKey directoryKey)
    {
        var options = new DbOptions<TDbContext>();
        _config(options);

        var key = _inner.BuildKey();

        var descriptor = options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
