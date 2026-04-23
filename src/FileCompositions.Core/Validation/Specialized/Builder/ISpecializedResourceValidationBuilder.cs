using FileCompositions.Core.File.Resource;

namespace FileCompositions.Core.Validation.Specialized.Builder;

public interface ISpecializedResourceValidationBuilder
{
    internal ISpecializedResourceValidationBuilder With(Func<IFileResource, Task> validation);
}
