using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder;

public interface IJsonDefinitionBuilder<TOwnership, TNecessity, TData> : IFileDefinitionBuilder, IJsonResourceBuilder<TData>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey key);
    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithName(string name);
    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseSerializerOptions(JsonSerializerOptions options);
    new IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation);

    new internal JsonDefinition<TOwnership, TNecessity, TData> Build(in IFileContext context);
    internal IJsonDefinitionDescriptor<TOwnership, TNecessity, TData> BuildDescriptor();
}
