using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Options.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;

internal abstract partial class AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData> : IJsonDefinitionBuilder<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build(DirectoryDefinitionKey directoryKey)
    {
        var options = new JsonOptions<TData>();
        _config(options);

        var key = _inner.BuildKey();

        var descriptor = options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
