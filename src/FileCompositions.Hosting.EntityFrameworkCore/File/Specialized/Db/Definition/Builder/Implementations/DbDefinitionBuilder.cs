using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Config;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;

public class DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext
{
    private readonly IDbConfig<TDbContext> _config;

    public DbDefinitionBuilder(IDbConfig<TDbContext> config) => _config = config;
    protected DbDefinitionBuilder(IDbConfig<TDbContext> config, FileDefinitionKey? key = default) : base(key) => _config = config;

    protected override DbDefinitionBuilder<TOwnership, TNecessity, TDbContext> Create<TNewOwnership, TNewNecessity>() => new(_config, Key);

    public override DbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External() => new(_config, Key);
    public DbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional() => new(_config, Key);


    internal FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build<TPlacement>(out FileDefinitionKey key)
        where TPlacement : DefinitionPlacement
    {
        if (Key is null)
            throw new NullReferenceException("File must have a key.");

        key = Key;

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }
}
