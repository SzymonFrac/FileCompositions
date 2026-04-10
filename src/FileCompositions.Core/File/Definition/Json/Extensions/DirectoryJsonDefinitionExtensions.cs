using FileCompositions.Core.DirectoryLocation.Projections.Resources;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Json.Extensions;

public static class DirectoryJsonDefinitionExtensions
{
    extension(IEnumerableDirectoryLocation enumerableDirectory)
    {
        public ValueTask<IJsonFileResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default) =>
            enumerableDirectory.GetResource<IJsonFileResource<TData>>(StorageResourceName.CreateJson(name), cancellationToken);
    }
    extension(IWriteableDirectoryLocation writeableDirectory)
    {
        public async ValueTask<IJsonFileResource<TData>> WriteJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            await writeableDirectory.CreateResource(StorageResourceName.CreateJson(name), cancellationToken);
            // return the IJson with that stream...
            throw new NotImplementedException();
        }
        public async ValueTask<IJsonFileResource<TData>?> TryWriteJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            var exists = await writeableDirectory.TryCreateResource(StorageResourceName.CreateJson(name), cancellationToken);
            if (!exists)
                return null;
            // return the IJson with that stream
            throw new NotImplementedException();
        }
    }
}