using FileCompositions.Core.File.Resource.Specialized.Json;

namespace FileCompositions.Core.Validation.Specialized.Json;

public interface IJsonResourceValidation<TData>
{
    abstract static void Validate(IJsonFileResource<TData> fileResource);
}
