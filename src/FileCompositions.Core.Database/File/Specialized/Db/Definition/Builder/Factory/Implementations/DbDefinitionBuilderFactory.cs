using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Factory.Implementations;

//internal sealed class DbDefinitionBuilderFactory<TInNecessity>(DirectoryDefinitionKey key) : IDbDefinitionBuilderFactory<TInNecessity>
//    where TInNecessity : DefinitionNecessity
//{
//    private readonly DirectoryDefinitionKey _key = key;

//    public IDbDefinitionBuilder<StrictDefinition, TInNecessity> Create() =>
//        new DbDefinitionBuilder<StrictDefinition, TInNecessity>(_key);

//    public IDbDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
//        where TOwnership : DefinitionOwnership
//        where TNecessity : DefinitionNecessity =>
//            new DbDefinitionBuilder<TOwnership, TNecessity>(_key);
//}

