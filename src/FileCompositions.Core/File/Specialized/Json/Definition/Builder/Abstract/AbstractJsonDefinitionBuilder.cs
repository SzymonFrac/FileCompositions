using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;

internal abstract partial class AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IJsonOptions<TData>> config) :
    IJsonDefinitionBuilder<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IJsonOptions<TData>> _config = config;

    //public IFileDefinitionBuilder<TNewOwnership, TNewPlacement, IJsonOptions<TData>> Create<TNewOwnership, TNewPlacement>()
    //    where TNewOwnership : DefinitionOwnership
    //    where TNewPlacement : DefinitionPlacement =>
    //        _inner.Create<TNewOwnership, TNewPlacement>()
    //            .Json(_config);

    public IJsonDefinitionBuilder<TOwnership, TPlacement, TData> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Json(_config);
}
