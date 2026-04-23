using FileCompositions.Core.Directory.Projections.Resources;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class DirectoryJsonDefinitionExtensions
{
    extension(IEnumerableDirectory enumerableDirectory)
    {
        public ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default) =>
            enumerableDirectory.GetResource<IJsonResource<TData>>(StorageResourceName.CreateJson(name), cancellationToken);
    }
    extension(IWriteableDirectory writeableDirectory)
    {
        public async ValueTask<IJsonResource<TData>> WriteJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            await writeableDirectory.CreateResource(StorageResourceName.CreateJson(name), cancellationToken);
            // return the IJson with that stream...
            throw new NotImplementedException();
        }
        public async ValueTask<IJsonResource<TData>?> TryWriteJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            var exists = await writeableDirectory.TryCreateResource(StorageResourceName.CreateJson(name), cancellationToken);
            if (!exists)
                return null;
            // return the IJson with that stream
            throw new NotImplementedException();
        }
    }
}