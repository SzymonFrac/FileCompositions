using FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

internal sealed class DbDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDbDefinitionBuilder<TOwnership, TNecessity>
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

        return new DbDefinition<TOwnership, TPlacement>(context, Key, Name)
        {
            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
        };
        
    }

    public IDbDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryKey, Key, Name)
        {
            InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
        };
    }
}
