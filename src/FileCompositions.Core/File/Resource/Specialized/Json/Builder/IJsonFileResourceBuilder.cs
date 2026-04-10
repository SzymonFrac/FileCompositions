using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.File.Resource.Specialized.Json.Descriptor;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder;

public interface IJsonFileResourceBuilder<TData>
{
    IJsonFileResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions serializerOptions);
    IJsonFileResourceBuilder<TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation);
    internal IJsonFileResource<TData> Build(IDirectoryLocation directory);
    internal IJsonFileResourceDescriptor<TData> BuildDescriptor(DirectoryLocationKey key);
}
