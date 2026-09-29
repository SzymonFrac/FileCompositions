using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Unspecified.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Abstract;

internal abstract partial class AbstractUnspecifiedDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IUnspecifiedOptions> config)
    : IUnspecifiedDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IUnspecifiedOptions> _config = config;

    public IUnspecifiedDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Unspecified(_config);
}
