using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension<TOwnership, TNecessity>(IDirectoryDefinition<TOwnership, TNecessity> directory)
        where TOwnership : Ownership
        where TNecessity : Necessity
    {
        //public async Task<IDllResource?> FindDllResourceAsync(string name, CancellationToken cancellationToken = default) =>
        //    await directory.Context.FileSystem.ExistsAsync(directory.Address.With(FileName.CreateDll(name)), cancellationToken)
        //        ? DllDefinition.Convert(new FileContext(directory.Context.FileSystem, directory.Address), name)
        //        : default;
    }
}
