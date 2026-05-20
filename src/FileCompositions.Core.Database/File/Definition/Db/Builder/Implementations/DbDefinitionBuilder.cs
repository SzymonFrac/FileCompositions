using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.Database.File.Definition.Db.Descriptor.Implementations;
using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder.Implementations;

internal class DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
    : FileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext
{
    internal DbDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) { }
    private DbDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) : base(directoryKey, key, name) { }

    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External() =>
        new DbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict() =>
        new DbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required() =>
        new DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional() =>
        new DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext>(DirectoryKey, Key, Name);

    public IDbDefinition<TOwnership, TPlacement, TDbContext> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbDefinition<TOwnership, TPlacement, TDbContext>(Key, context, Name);
        return db;
    }

    public IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryKey, Key, Name);
        return db;
    }
}

internal class DbDefinitionBuilder<TOwnership, TNecessity>
    : FileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    internal DbDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) { }
    private DbDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) : base(directoryKey, key, name) { }

    public IDbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
    public IDbDefinitionBuilder<TOwnership, TNecessity> WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDbDefinitionBuilder<ExternalDefinition, TNecessity> External() =>
        new DbDefinitionBuilder<ExternalDefinition, TNecessity>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<StrictDefinition, TNecessity> Strict() =>
        new DbDefinitionBuilder<StrictDefinition, TNecessity>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<TOwnership, RequiredDefinition> Required() =>
        new DbDefinitionBuilder<TOwnership, RequiredDefinition>(DirectoryKey, Key, Name);
    public IDbDefinitionBuilder<TOwnership, OptionalDefinition> Optional() =>
        new DbDefinitionBuilder<TOwnership, OptionalDefinition>(DirectoryKey, Key, Name);

    public IDbDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbDefinition<TOwnership, TPlacement>(Key, context, Name);
        return db;
    }

    public IDbDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryKey, Key, Name);
        return db;
    }
}
