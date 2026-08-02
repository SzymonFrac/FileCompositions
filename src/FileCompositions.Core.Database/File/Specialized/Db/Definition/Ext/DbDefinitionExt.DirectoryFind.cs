using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.FileSystem.Source.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TOwnership, TNecessity>(IDirectoryDefinition<TOwnership, TNecessity> directory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public async ValueTask<IDbResource?> GetDbResourceAsync(string name, CancellationToken cancellationToken = default) =>
            await directory.Context.FileSystem.ExistsAsync(directory.Address.With(FileSystemResourceName.CreateDb(name)), cancellationToken)
                ? DbDefinition.Convert(new FileContext(new FileSystemSource(directory.Context.FileSystem), directory.Address), name)
                : default;
    }
}
