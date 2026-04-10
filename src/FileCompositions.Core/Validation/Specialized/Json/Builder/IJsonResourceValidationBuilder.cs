using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Validation.Specialized.Builder;

namespace FileCompositions.Core.Validation.Specialized.Json.Builder;

public interface IJsonResourceValidationBuilder<TData> : ISpecializedResourceValidationBuilder
{
    internal IJsonResourceValidationBuilder<TData> With(Func<IJsonFileResource<TData>, Task> validation);
    internal IReadOnlyCollection<Func<IJsonFileResource<TData>, Task>> Build();
}
