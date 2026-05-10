using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Factory.Implementations;

internal class DllDefinitionBuilderFactory<TInOwnership, TInNecessity>(DirectoryDefinitionKey key) : IDllDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    private readonly DirectoryDefinitionKey _key = key;

    public IDllDefinitionBuilder<TInOwnership, TInNecessity> Create() =>
        new DllDefinitionBuilder<TInOwnership, TInNecessity>(_key);
    public IDllDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DllDefinitionBuilder<TOwnership, TNecessity>(_key);
}
