using FileCompositions.Core.Database.File.Specialized.Db.Config;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

public class DbDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DbDefinitionBuilder<TOwnership, TNecessity>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IDbConfig _config;

    public DbDefinitionBuilder(IDbConfig config) => _config = config;
    protected DbDefinitionBuilder(IDbConfig config, FileDefinitionKey? key = default) : base(key) => _config = config;

    protected override DbDefinitionBuilder<TOwnership, TNecessity> Create<TNewOwnership, TNewNecessity>() => new(_config, Key);

    public override DbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DbDefinitionBuilder<ExternalDefinition, TNecessity> External() => new(_config, Key);
    public DbDefinitionBuilder<StrictDefinition, TNecessity> Strict() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, RequiredDefinition> Required() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => new(_config, Key);


    internal FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build<TPlacement>(out FileDefinitionKey key)
        where TPlacement : DefinitionPlacement
    {
        if (Key is null)
            throw new NullReferenceException("File must have a key.");

        key = Key;

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }
}
