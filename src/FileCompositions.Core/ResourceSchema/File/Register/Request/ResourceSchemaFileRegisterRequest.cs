using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.ResourceSchema.File.Register.Request;

internal readonly record struct ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition>(
    DirectoryDefinitionKey DirectoryKey, // needs dir key?
    FileDefinitionKey FileKey,
    FileDefinitionRequest<TOwnership, TPlacement, TDefinition> Request)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : IFileDefinition<TOwnership, TPlacement>;
