using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension<TOwnership, TNecessity>(IDirectoryDefinition<TOwnership, TNecessity> directory)
        where TOwnership : Ownership
        where TNecessity : Necessity
    {
        //public async ValueTask<IDbResource?> GetDbResourceAsync(string name, CancellationToken cancellationToken = default) =>
        //    await directory.Context.FileSystem.ExistsAsync(directory.Address.With(FileName.CreateDb(name)), cancellationToken)
        //        ? DbDefinition.Convert(new FileContext(directory.Context.FileSystem, directory.Address), name)
        //        : default;
    }
}
