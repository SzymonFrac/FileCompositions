using FileCompositions.Core.Database.File.Specialized.Db.Config;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

//internal sealed class DbDefinitionBuilder<TOwnership, TNecessity>
//    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity>
//        where TOwnership : DefinitionOwnership
//        where TNecessity : DefinitionNecessity
//{
//    internal DbDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) { }
//    private DbDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) : base(directoryKey, key, name) { }

//    public IDbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
//    {
//        Key = key;
//        return this;
//    }
//    public IDbDefinitionBuilder<TOwnership, TNecessity> WithName(string name)
//    {
//        Name = name;
//        return this;
//    }

//    public IDbDefinitionBuilder<ExternalDefinition, TNecessity> External() =>
//        new DbDefinitionBuilder<ExternalDefinition, TNecessity>(DirectoryKey, Key, Name);
//    public IDbDefinitionBuilder<StrictDefinition, TNecessity> Strict() =>
//        new DbDefinitionBuilder<StrictDefinition, TNecessity>(DirectoryKey, Key, Name);
//    public IDbDefinitionBuilder<TOwnership, RequiredDefinition> Required() =>
//        new DbDefinitionBuilder<TOwnership, RequiredDefinition>(DirectoryKey, Key, Name);
//    public IDbDefinitionBuilder<TOwnership, OptionalDefinition> Optional() =>
//        new DbDefinitionBuilder<TOwnership, OptionalDefinition>(DirectoryKey, Key, Name);

//    public IDbDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DbDefinition<TOwnership, TPlacement>(context, Key, Name)
//        {
//            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
//        };

//    }

//    public IDbDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryKey, Key, Name)
//        {
//            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
//        };
//    }
//}

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

        // get config's delegate
        // partially apply here...
        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }

    //public IFileDefinition<TOwnership, TPlacement> Definition<TPlacement>(FileDefinitionKey key, IFileContext context)
    //    where TPlacement : DefinitionPlacement
    //        => new JsonDefinition<TOwnership, TPlacement, TData>(context, key);
};
