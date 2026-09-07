using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder;

public interface IJsonDefinitionBuilder<TOwnership, TPlacement, TData> 
    : IFileDefinitionBuilder<TOwnership, TPlacement, IJsonDefinitionBuilder<TOwnership, TPlacement, TData>>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build(DirectoryDefinitionKey directoryKey);
}
