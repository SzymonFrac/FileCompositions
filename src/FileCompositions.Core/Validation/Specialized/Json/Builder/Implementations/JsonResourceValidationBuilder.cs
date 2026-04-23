using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Validation.Specialized.Builder;

namespace FileCompositions.Core.Validation.Specialized.Json.Builder.Implementations;

internal class JsonResourceValidationBuilder<TData> : IJsonResourceValidationBuilder<TData>
{
    private readonly List<Func<IJsonResource<TData>, Task>> _validations = [];

    public ISpecializedResourceValidationBuilder With(Func<IFileResource, Task> validation)
    {
        _validations.Add(validation);
        return this;
    }
    public IJsonResourceValidationBuilder<TData> With(Func<IJsonResource<TData>, Task> validation)
    {
        _validations.Add(validation);
        return this;
    }

    public IReadOnlyCollection<Func<IJsonResource<TData>, Task>> Build() => _validations;
}
