using FileCompositions.Core.Database.File.Init;
using FileCompositions.Core.Database.File.Interface.Specialized.Db;
using FileCompositions.Core.Database.File.Operator.Specialized.Db;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Resource.Db;

public interface IDbResource : IFileResource,
    IDbInterface<ExternalDefinition, RequiredInRequired>,
    IDbInit<ExternalDefinition, RequiredInRequired>,
    IDbOperator<ExternalDefinition, RequiredInRequired>;