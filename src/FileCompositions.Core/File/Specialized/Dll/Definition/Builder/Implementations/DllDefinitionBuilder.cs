using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;

internal sealed class DllDefinitionBuilder<TOwnership, TPlacement> : AbstractDllDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public DllDefinitionBuilder(IDllOptions options) : base(options) { }
    private DllDefinitionBuilder(IDllOptions options, FileDefinitionKey? key) : base(options, key) { }

    public override IDllDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>() =>
        new DllDefinitionBuilder<TNewOwnership, TNewPlacement>(Options, Key);

    public override IDllDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
}
