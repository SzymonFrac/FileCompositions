using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class DirectoryInterfaceResolveJson
{
    extension(IDirectoryInterface<RequiredDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            var json = await @interface.StorageBackend.Exists(@interface.Address.With(StorageResourceName.CreateJson(name)), cancellationToken)
                ? JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name)
                : default;

            if (json is null)
                return default;

            try
            {
                await json.Read(cancellationToken);
            }
            catch (Exception)
            {
                return default;
            }

            return json;
        }
    }

    extension(IDirectoryInterface<OptionalDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            var json = await @interface.StorageBackend.Exists(@interface.Address.With(StorageResourceName.CreateJson(name)), cancellationToken)
                ? JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name)
                : default;

            if (json is null)
                return default;

            try
            {
                await json.Read(cancellationToken);
            }
            catch (Exception)
            {
                return default;
            }

            return json;
        }
    }
}
