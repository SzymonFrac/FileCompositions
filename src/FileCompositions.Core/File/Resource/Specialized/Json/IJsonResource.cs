using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.File.Operator.Specialized.Json;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Json;

public interface IJsonResource<TData> : IFileResource,
    IJsonInterface<ExternalDefinition, RequiredInRequired, TData>,
    IJsonOperator<ExternalDefinition, RequiredInRequired, TData>;