using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Validation.Specialized.Builder;

namespace FileCompositions.Core.Validation.Specialized.Json.Builder;

public interface IJsonResourceValidationBuilder<TData> : ISpecializedResourceValidationBuilder
{
    internal IJsonResourceValidationBuilder<TData> With(Func<IJsonResource<TData>, Task> validation);
    internal IReadOnlyCollection<Func<IJsonResource<TData>, Task>> Build();
}
