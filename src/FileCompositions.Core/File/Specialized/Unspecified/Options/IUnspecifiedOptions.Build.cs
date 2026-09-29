using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.File.Specialized.Unspecified.Definition;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Options;

public partial interface IUnspecifiedOptions : IFileOptions<IUnspecifiedOptions>
{
    internal FileResourceRequest<IDllResource> Build();
    internal FileDefinitionDescriptor<TOwnership, TPlacement, IUnspecifiedDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement;
}
