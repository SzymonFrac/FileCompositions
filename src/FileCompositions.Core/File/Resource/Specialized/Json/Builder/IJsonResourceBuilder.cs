using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder;

public interface IJsonResourceBuilder<TData> : IFileResourceBuilder
{
    IJsonResourceBuilder<TData> WithName(string name);
    IJsonResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions serializerOptions);
    IJsonResourceBuilder<TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation);

    internal IJsonResource<TData> Build(in IFileContext context);
}
