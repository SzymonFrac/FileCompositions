using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Factory;

internal interface IDllDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    IDllDefinitionBuilder<TInOwnership, TInNecessity> Create();
    internal IDllDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
