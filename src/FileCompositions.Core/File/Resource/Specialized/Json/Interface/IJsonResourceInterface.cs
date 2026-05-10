using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Interface;

public interface IJsonResourceInterface<TData> : IJsonInterface<RequiredInRequired, TData>;
