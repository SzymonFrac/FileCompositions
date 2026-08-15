using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.File.No.Definition.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoDefinitionBuilder<TOwnership, TPlacement>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, INoDefinition<TOwnership, TPlacement>, INoDefinitionBuilder<TOwnership, TPlacement>>,
    INoDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public override ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, INoDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey)
    {
        var key = BuildKey();

        var request = new FileDefinitionRequest<TOwnership, TPlacement, INoDefinition<TOwnership, TPlacement>>(
            (in context) => new NoDefinition<TOwnership, TPlacement>(context, key));

        return new(directoryKey, key, request);
    }
}
