using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Definition.Builder.Abstract;

internal abstract partial class AbstractFileDefinitionBuilder<TOwnership, TPlacement, TDefinition, TBuilder> : IFileDefinitionBuilder<TOwnership, TPlacement, TDefinition, TBuilder>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : IFileDefinition<TOwnership, TPlacement>
    where TBuilder : IFileDefinitionBuilder<TOwnership, TPlacement, TDefinition, TBuilder>
{
    public abstract ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> Build(DirectoryDefinitionKey directoryKey);
}