using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Factory.Implementations;

internal sealed class DllDefinitionBuilderFactory<TInNecessity>(DirectoryDefinitionKey key) : IDllDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    private readonly DirectoryDefinitionKey _key = key;
    public IDllDefinitionBuilder<StrictDefinition, TInNecessity> Create() =>
        new DllDefinitionBuilder<StrictDefinition, TInNecessity>(_key);
    public IDllDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DllDefinitionBuilder<TOwnership, TNecessity>(_key);
}
