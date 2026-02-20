using FileCompositions.Core.FileResource.Specialized;
using FileCompositions.Core.FileResource.Specialized.Json;
using FileCompositions.Core.Validation.Specialized.Builder;

namespace FileCompositions.Core.Validation.Specialized.Json.Builder.Implementations;

internal class JsonResourceValidationBuilder<TData> : IJsonResourceValidationBuilder<TData>
{
    private readonly List<Func<IJsonFileResource<TData>, Task>> _validations = [];

    public ISpecializedResourceValidationBuilder With(Func<ISpecializedFileResource, Task> validation)
    {
        _validations.Add(validation);
        return this;
    }
    public IJsonResourceValidationBuilder<TData> With(Func<IJsonFileResource<TData>, Task> validation)
    {
        _validations.Add(validation);
        return this;
    }

    public IReadOnlyCollection<Func<IJsonFileResource<TData>, Task>> Build() => _validations;
}
