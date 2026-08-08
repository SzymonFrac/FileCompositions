using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
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

//internal sealed class DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
//    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
//        where TOwnership : DefinitionOwnership
//        where TNecessity : DefinitionNecessity
//        where TDbContext : DbContext
//{
//    private bool migrate;

//    internal DbDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) => migrate = false;
//    private DbDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name, bool a) : base(directoryKey, key, name) =>
//        migrate = a;

//    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key)
//    {
//        Key = key;
//        return this;
//    }
//    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithName(string name)
//    {
//        Name = name;
//        return this;
//    }
//    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> AutoMigrate(bool a = true)
//    {
//        migrate = a;
//        return this;
//    }

//    public IDbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External() =>
//        new DbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name, migrate);
//    public IDbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict() =>
//        new DbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name, migrate);
//    public IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required() =>
//        new DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext>(DirectoryKey, Key, Name, migrate);
//    public IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional() =>
//        new DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext>(DirectoryKey, Key, Name, migrate);

//    public IDbDefinition<TOwnership, TPlacement, TDbContext> Build<TPlacement>(in IFileContext context)
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DbDefinition<TOwnership, TPlacement, TDbContext>(context, Key, Name)
//        {
//            InitPolicy = migrate
//                ? new MigrateDbInitPolicy<TOwnership, TPlacement, TDbContext>()
//                : new DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext>()
//        };
//    }

//    public IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> BuildDescriptor<TPlacement>()
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryKey, Key, Name)
//        {
//            InitPolicy = migrate
//                ? new MigrateDbInitPolicy<TOwnership, TPlacement, TDbContext>()
//                : new DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext>()
//        };
//    }
//}

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

        // get config's delegate
        // partially apply here...
        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }

    //public IFileDefinition<TOwnership, TPlacement> Definition<TPlacement>(FileDefinitionKey key, IFileContext context)
    //    where TPlacement : DefinitionPlacement
    //        => new JsonDefinition<TOwnership, TPlacement, TData>(context, key);
};
