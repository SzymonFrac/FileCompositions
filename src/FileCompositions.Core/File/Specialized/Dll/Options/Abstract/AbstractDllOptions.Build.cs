using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Dll.Definition;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.File.Specialized.Dll.Resource.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Options.Abstract;

internal abstract partial class AbstractDllOptions : AbstractFileOptions<IDllOptions>, IDllOptions
{
    public FileResourceRequest<IDllResource> Build() =>
        (in context) => new DllResource(context, Name);
    public FileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement =>
            key => (in context) => new DllDefinition<TOwnership, TPlacement>(context, key, Name)
            {
                InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
            };
}
