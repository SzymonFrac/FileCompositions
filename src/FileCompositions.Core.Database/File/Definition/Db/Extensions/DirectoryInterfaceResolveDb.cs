using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Database.File.Definition.Db.Extensions;

public static class DirectoryInterfaceResolveDb
{
    extension<TOwnership, TNecessity>(IDirectoryInterface<TOwnership, TNecessity> @interface)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public async ValueTask<IDbResource?> GetDbResource(string name, CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.Address.With(FileSystemResourceName.CreateDb(name)), cancellationToken)
                ? DbDefinition.Convert(new FileContext(@interface.StorageBackend, @interface.Address), name)
                : default;
    }
}
