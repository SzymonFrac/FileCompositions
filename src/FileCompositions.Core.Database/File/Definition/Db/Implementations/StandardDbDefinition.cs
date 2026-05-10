using FileCompositions.Core.Database.File.Definition.Db.Abstract;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Implementations;

internal class StandardDbDefinition<TOwnership, TNecessity, TDbContext>(FileDefinitionKey key, IFileContext context, string name)
    : DbDefinition<TOwnership, TNecessity, TDbContext>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;

internal class StandardDbDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IFileContext context, string name)
    : DbDefinition<TOwnership, TNecessity>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
