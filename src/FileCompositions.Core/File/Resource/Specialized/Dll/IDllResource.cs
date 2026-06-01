using FileCompositions.Core.File.Interface.Specialized.Dll;
using FileCompositions.Core.File.Operator.Specialized.Dll;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Dll;

public interface IDllResource : IFileResource,
    IDllInterface<ExternalDefinition, RequiredInRequired>,
    IDllOperator<ExternalDefinition, RequiredInRequired>;
