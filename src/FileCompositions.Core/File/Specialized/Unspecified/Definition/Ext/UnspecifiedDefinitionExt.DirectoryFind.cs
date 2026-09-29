using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Ext;

public static partial class UnspecifiedDefinitionExt
{
    extension<TOwnership, TNecessity>(IDirectoryDefinition<TOwnership, TNecessity> directory)
        where TOwnership : Ownership
        where TNecessity : Necessity
    {
        //public async Task<IUnspecifiedResource?> FindUnspecifiedResourceAsync(string name, CancellationToken cancellationToken = default) =>
        //    await directory.Context.FileSystem.ExistsAsync(directory.Address.With(FileName.CreateUnspecified(name)), cancellationToken)
        //        ? UnspecifiedDefinition.Convert(new FileContext(directory.Context.FileSystem, directory.Address), name)
        //        : default;
    }
}
