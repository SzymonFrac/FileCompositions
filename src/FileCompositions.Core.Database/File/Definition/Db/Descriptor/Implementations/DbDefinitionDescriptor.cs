using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Descriptor.Implementations;

internal class DbDefinitionDescriptor<TOwnership, TNecessity, TDbContext>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : FileDefinitionDescriptor<IDbDefinition<TOwnership, TNecessity, TDbContext>, TOwnership, TNecessity>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TNecessity, TDbContext>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext
{
    public override IDbDefinition<TOwnership, TNecessity, TDbContext> Activate(in IFileContext context) =>
        new StandardDbDefinition<TOwnership, TNecessity, TDbContext>(Key, context, Name);
}


internal class DbDefinitionDescriptor<TOwnership, TNecessity>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : FileDefinitionDescriptor<IDbDefinition<TOwnership, TNecessity>, TOwnership, TNecessity>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public override IDbDefinition<TOwnership, TNecessity> Activate(in IFileContext context) =>
        new StandardDbDefinition<TOwnership, TNecessity>(Key, context, Name);
}
