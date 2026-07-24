using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Resource;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Extensions;

public static class DirectoryInterfaceResolveDll
{
    extension<TOwnership, TNecessity>(IDirectoryInterface<TOwnership, TNecessity> @interface)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public async Task<IDllResource?> GetDllResourceAsync(string name, CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetAddress().With(FileSystemResourceName.CreateDll(name)), cancellationToken)
                ? DllDefinition.Convert(new FileContext(@interface.StorageBackend, @interface.GetAddress()), name)
                : default;
    }
}
