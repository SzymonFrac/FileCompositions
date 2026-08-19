using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Json.Definition;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Options;

public partial interface IJsonOptions<TData> : IFileOptions<IJsonOptions<TData>>
{
    internal FileResourceRequest<IJsonResource<TData>> Build();
    internal FileDefinitionDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
