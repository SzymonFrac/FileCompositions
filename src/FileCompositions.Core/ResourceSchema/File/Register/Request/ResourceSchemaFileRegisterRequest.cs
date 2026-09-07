using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.ResourceSchema.File.Register.Request;

internal readonly record struct ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition>(
    DirectoryDefinitionKey DirectoryKey, // needs dir key?
    FileDefinitionKey FileKey,
    FileDefinitionRequest<TOwnership, TPlacement, TDefinition> Request)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : IFileDefinition<TOwnership, TPlacement>;
