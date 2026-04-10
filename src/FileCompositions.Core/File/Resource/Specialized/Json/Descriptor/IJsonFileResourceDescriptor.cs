using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized.Descriptor;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Descriptor;

internal interface IJsonFileResourceDescriptor<TData> : ISpecializedFileResourceDescriptor
{
    JsonFileResourceFormatContext Format { get; }
    new IJsonFileResource<TData> Activate(IDirectoryLocation directory);
}
