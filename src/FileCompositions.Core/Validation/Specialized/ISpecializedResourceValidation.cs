using FileCompositions.Core.File.Resource;

namespace FileCompositions.Core.Validation.Specialized;

public interface ISpecializedResourceValidation
{
    abstract static Task<bool> Validate(IFileResource fileResource);
}
