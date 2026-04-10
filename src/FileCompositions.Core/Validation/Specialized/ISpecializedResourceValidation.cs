using FileCompositions.Core.File.Resource.Specialized;

namespace FileCompositions.Core.Validation.Specialized;

public interface ISpecializedResourceValidation
{
    abstract static Task<bool> Validate(ISpecializedFileResource fileResource);
}
