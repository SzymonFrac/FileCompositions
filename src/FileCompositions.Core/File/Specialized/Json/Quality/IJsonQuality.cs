using FileCompositions.Core.File.Quality;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Quality;

public interface IJsonQuality<TOwnership, TPlacement, TData> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    JsonFormat Format { get; }
}
