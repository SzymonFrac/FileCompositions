using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;

namespace FileCompositions.Core.File.Definition.Json.Builder;

public interface IJsonDefinitionBuilder<TData> : IJsonFileResourceBuilder<TData>
{
    new internal IJsonDefinition<TData> Build(IDirectoryLocation directory);
}
