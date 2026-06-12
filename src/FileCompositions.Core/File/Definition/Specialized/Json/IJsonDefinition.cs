using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Init.Specialized.Json;
using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.File.Operator.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json;

public interface IJsonDefinition<TOwnership, TPlacement, TData> : IFileDefinition<TOwnership, TPlacement>,
    IJsonInterface<TOwnership, TPlacement, TData>,
    IJsonInit<TOwnership, TPlacement, TData>,
    IJsonOperator<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal interface IJsonDefinition : IFileDefinition
{
    abstract static IJsonResource<TData> Convert<TData>(in IFileContext context, string name);
}
