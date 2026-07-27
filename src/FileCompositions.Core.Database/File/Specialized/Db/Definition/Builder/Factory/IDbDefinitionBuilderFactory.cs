using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Factory;

public interface IDbDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    IDbDefinitionBuilder<StrictDefinition, TInNecessity> Create();
    internal IDbDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
