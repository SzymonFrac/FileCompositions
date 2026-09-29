using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Specialized.Unspecified.Options.Implementations;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Abstract;

internal abstract partial class AbstractUnspecifiedDefinitionBuilder<TOwnership, TPlacement> : IUnspecifiedDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IUnspecifiedDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey)
    {
        var options = new UnspecifiedOptions();
        _config(options);

        var key = _inner.BuildKey();

        var descriptor = options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
