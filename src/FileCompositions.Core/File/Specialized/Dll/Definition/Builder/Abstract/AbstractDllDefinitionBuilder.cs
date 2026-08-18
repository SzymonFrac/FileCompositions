using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;

internal abstract partial class AbstractDllDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDllOptions> config)
    : IDllDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IDllOptions> _config = config;

    public IDllDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Dll(_config);
}
