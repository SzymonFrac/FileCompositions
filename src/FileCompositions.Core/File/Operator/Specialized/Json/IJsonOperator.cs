using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Operator.Specialized.Json;

public interface IJsonOperator<TOwnership, TPlacement, TData> : IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal JsonInterfaceFormat Format { get; }
}
