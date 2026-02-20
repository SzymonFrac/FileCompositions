using FileCompositions.Core.FileResource.Specialized.Json;

namespace FileCompositions.Core.Validation.Specialized.Json;

public interface IJsonResourceValidation<TData>
{
    abstract static void Validate(IJsonFileResource<TData> fileResource);
}
