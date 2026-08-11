using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

public class DbDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DbDefinitionBuilder<TOwnership, TNecessity>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IDbOptions _config;

    public DbDefinitionBuilder(IDbOptions config) => _config = config;
    protected DbDefinitionBuilder(IDbOptions config, FileDefinitionKey? key = default) : base(key) => _config = config;

    public override DbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DbDefinitionBuilder<ExternalDefinition, TNecessity> External() => new(_config, Key);
    public DbDefinitionBuilder<StrictDefinition, TNecessity> Strict() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, RequiredDefinition> Required() => new(_config, Key);
    public DbDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => new(_config, Key);


    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build<TPlacement>(DirectoryDefinitionKey directoryKey)
        where TPlacement : DefinitionPlacement
    {
        var key = BuildKey();

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
