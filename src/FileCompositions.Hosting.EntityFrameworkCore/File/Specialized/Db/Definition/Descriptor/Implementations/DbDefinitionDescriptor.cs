using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor.Implementations;

internal sealed class DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    public required IDbInitPolicy<TOwnership, TPlacement, TDbContext> InitPolicy { get; init; }

    public override IDbDefinition<TOwnership, TPlacement, TDbContext> Activate(in IFileContext context) =>
        new DbDefinition<TOwnership, TPlacement, TDbContext>(context, Key, Name)
        {
            InitPolicy = InitPolicy
        };
}
