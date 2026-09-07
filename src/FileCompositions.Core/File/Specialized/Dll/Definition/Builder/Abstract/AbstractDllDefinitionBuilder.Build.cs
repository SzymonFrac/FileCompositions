using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Options.Implementations;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;

internal abstract partial class AbstractDllDefinitionBuilder<TOwnership, TPlacement> : IDllDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey)
    {
        var options = new DllOptions();
        _config(options);

        var key = _inner.BuildKey();

        var descriptor = options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
