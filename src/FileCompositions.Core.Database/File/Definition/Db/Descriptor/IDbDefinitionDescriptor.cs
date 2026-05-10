using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Descriptor;

internal interface IDbDefinitionDescriptor<TOwnership, TNecessity, TDbContext>
    : IFileDefinitionDescriptor<IDbDefinition<TOwnership, TNecessity, TDbContext>, TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;

internal interface IDbDefinitionDescriptor<TOwnership, TNecessity>
    : IFileDefinitionDescriptor<IDbDefinition<TOwnership, TNecessity>, TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
