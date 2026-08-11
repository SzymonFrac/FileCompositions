using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;

public class DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext
{
    private readonly IDbOptions<TDbContext> _config;

    public DbDefinitionBuilder(IDbOptions<TDbContext> config) => _config = config;
    protected DbDefinitionBuilder(IDbOptions<TDbContext> config, FileDefinitionKey? key = default) : base(key) => _config = config;

    public override DbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External() => new(_config, Key);
    public DbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional() => new(_config, Key);


    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build<TPlacement>(DirectoryDefinitionKey directoryKey)
        where TPlacement : DefinitionPlacement
    {
        var key = BuildKey();

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
