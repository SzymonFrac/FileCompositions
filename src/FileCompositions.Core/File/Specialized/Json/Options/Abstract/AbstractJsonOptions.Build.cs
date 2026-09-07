using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.File.Specialized.Json.Definition;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.File.Specialized.Json.Resource.Implementations;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Options.Abstract;

internal abstract partial class AbstractJsonOptions<TData> : AbstractFileOptions<IJsonOptions<TData>>, IJsonOptions<TData>
{
    protected JsonFormat BuildJsonFormat() => new(SerializerOptions);

    public FileResourceRequest<IJsonResource<TData>> Build() =>
        (in context) => new JsonResource<TData>(context, Name, BuildJsonFormat());
    public FileDefinitionDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement =>
            key => (in context) => new JsonDefinition<TOwnership, TPlacement, TData>(context, key, Name, BuildJsonFormat())
            {
                InitPolicy = new DefaultJsonInitPolicy<TOwnership, TPlacement, TData>()
            };
}
