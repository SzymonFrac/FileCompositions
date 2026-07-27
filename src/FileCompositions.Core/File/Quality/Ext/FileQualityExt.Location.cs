using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Quality.Ext;

public static partial class FileQualityExt
{
    extension<TOwnership, TPlacement>(IFileQuality<TOwnership, TPlacement> file)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public FileSystemLocation GetLocation() => file.Context.Address.With(file.Name);
    }
}
