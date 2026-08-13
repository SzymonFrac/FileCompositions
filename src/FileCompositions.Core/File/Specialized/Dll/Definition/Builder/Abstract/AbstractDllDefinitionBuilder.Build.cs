using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;

internal abstract partial class AbstractDllDefinitionBuilder<TOwnership, TPlacement>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>, IDllDefinitionBuilder<TOwnership, TPlacement>>,
    IDllDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public override ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey)
    {
        var key = BuildKey();

        var descriptor = Options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
