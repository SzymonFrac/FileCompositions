using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.File.Specialized.Dll.Resource.Implementations;
using FileCompositions.Core.File.Specialized.Unspecified.Definition;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Options.Abstract;

internal abstract partial class AbstractUnspecifiedOptions : AbstractFileOptions<IUnspecifiedOptions>, IUnspecifiedOptions
{
    public FileResourceRequest<IDllResource> Build() =>
        (in context) => new DllResource(context, Name);
    public FileDefinitionDescriptor<TOwnership, TPlacement, IUnspecifiedDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement =>
            key => (in context) => new UnspecifiedDefinition<TOwnership, TPlacement>(context, key, Name)
            {
                InitPolicy = new DefaultUnspecifiedInitPolicy<TOwnership, TPlacement>()
            };
}
