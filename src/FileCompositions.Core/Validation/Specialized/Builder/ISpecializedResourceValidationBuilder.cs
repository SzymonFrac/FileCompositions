using FileCompositions.Core.File.Resource.Specialized;

namespace FileCompositions.Core.Validation.Specialized.Builder;

public interface ISpecializedResourceValidationBuilder
{
    internal ISpecializedResourceValidationBuilder With(Func<ISpecializedFileResource, Task> validation);
}
