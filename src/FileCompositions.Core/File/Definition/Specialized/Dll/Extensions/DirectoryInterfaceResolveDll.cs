using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;

public static class DirectoryInterfaceResolveDll
{
    extension<TOwnership, TNecessity>(IDirectoryInterface<TOwnership, TNecessity> @interface)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
    {
        public async ValueTask<IDllResource?> GetDllResource(string name, CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.Address.With(StorageResourceName.CreateDll(name)), cancellationToken)
                ? DllDefinition.Convert(new FileContext(@interface.StorageBackend, @interface.Address), name)
                : default;
    }
}
