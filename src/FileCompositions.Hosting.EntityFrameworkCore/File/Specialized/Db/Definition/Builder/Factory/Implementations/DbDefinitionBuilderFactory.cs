using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory.Implementations;

//public sealed class DbDefinitionBuilderFactory<TInNecessity>(DirectoryDefinitionKey key) : IDbDefinitionBuilderFactory<TInNecessity>
//    where TInNecessity : DefinitionNecessity
//{
//    public DirectoryDefinitionKey Key { get; } = key;

//    public IDbDefinitionBuilder<StrictDefinition, TInNecessity, TDbContext> Create<TDbContext>()
//        where TDbContext : DbContext =>
//            new DbDefinitionBuilder<StrictDefinition, TInNecessity, TDbContext>(Key);

//    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> Create<TOwnership, TNecessity, TDbContext>()
//        where TOwnership : DefinitionOwnership
//        where TNecessity : DefinitionNecessity
//        where TDbContext : DbContext =>
//            new DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>(Key);
//}
