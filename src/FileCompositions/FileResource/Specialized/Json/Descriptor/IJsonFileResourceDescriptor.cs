using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.FileResource.Specialized.Descriptor;
using FileCompositions.Core.FileResource.Specialized.Json.FormatContext;

namespace FileCompositions.Core.FileResource.Specialized.Json.Descriptor;

internal interface IJsonFileResourceDescriptor<TData> : ISpecializedFileResourceDescriptor
{
    JsonFileResourceFormatContext Format { get; }
    new IJsonFileResource<TData> Activate(IDirectoryLocation directory);
}
