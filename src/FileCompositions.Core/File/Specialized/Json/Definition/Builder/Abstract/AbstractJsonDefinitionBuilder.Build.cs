using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;

internal abstract partial class AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>, IJsonDefinitionBuilder<TOwnership, TPlacement, TData>>,
    IJsonDefinitionBuilder<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public override ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build(DirectoryDefinitionKey directoryKey)
    {
        var key = BuildKey();
        
        var descriptor = Options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
