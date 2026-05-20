using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Descriptor.Implementations;

internal class DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : FileDefinitionDescriptor<IDbDefinition<TOwnership, TPlacement, TDbContext>, TOwnership, TPlacement>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    public override IDbDefinition<TOwnership, TPlacement, TDbContext> Activate(in IFileContext context) =>
        new DbDefinition<TOwnership, TPlacement, TDbContext>(Key, context, Name);
}


internal class DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : FileDefinitionDescriptor<IDbDefinition<TOwnership, TPlacement>, TOwnership, TPlacement>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public override IDbDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
        new DbDefinition<TOwnership, TPlacement>(Key, context, Name);
}
