using FileCompositions.Core.File.Quality;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Quality;

public interface IJsonQuality<TOwnership, TPlacement, TData> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    JsonFormat Format { get; }
}
