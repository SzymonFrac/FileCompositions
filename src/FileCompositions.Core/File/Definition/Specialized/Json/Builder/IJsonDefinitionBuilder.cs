using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder;

public interface IJsonDefinitionBuilder<TOwnership, TNecessity, TData> : IFileDefinitionBuilder<TOwnership, TNecessity>, IJsonResourceBuilder<TData>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithName(string name);

    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseSerializerOptions(JsonSerializerOptions serializerOptions);
    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation);

    new internal IJsonDefinition<TOwnership, TNecessity, TData> Build(IDirectoryLocation directory);
}
