using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Descriptor;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Descriptor.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init.Policy.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder.Implementations;

internal class DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext
{
    private bool migrate;

    internal DbDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) => migrate = false;
    private DbDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name, bool a) : base(directoryKey, key, name) =>
        migrate = a;

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
    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> AutoMigrate(bool a = true)
    {
        migrate = a;
        return this;
    }

    public IDbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External() =>
        new DbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name, migrate);
    public IDbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict() =>
        new DbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext>(DirectoryKey, Key, Name, migrate);
    public IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required() =>
        new DbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext>(DirectoryKey, Key, Name, migrate);
    public IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional() =>
        new DbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext>(DirectoryKey, Key, Name, migrate);

    public IDbDefinition<TOwnership, TPlacement, TDbContext> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new DbDefinition<TOwnership, TPlacement, TDbContext>(context, Key, Name)
        {
            InitPolicy = migrate
                ? new MigrateDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>()
                : new DefaultDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>()
        };
    }

    public IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryKey, Key, Name)
        {
            InitPolicy = migrate
                ? new MigrateDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>()
                : new DefaultDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>()
        };
    }
}
