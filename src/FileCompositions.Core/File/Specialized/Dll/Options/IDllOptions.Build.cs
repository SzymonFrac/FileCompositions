using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Dll.Definition;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Options;

public partial interface IDllOptions : IFileOptions<IDllOptions>
{
    internal FileResourceRequest<IDllResource> Build();
    internal FileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
