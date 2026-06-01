using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class DirectoryInterfaceResolveJson
{
    extension(IDirectoryInterface<StrictDefinition, RequiredDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name);
                await json.Read(cancellationToken).ConfigureAwait(false);

                return json;
            }
            catch
            {
                return default;
            }
        }
    }

    extension(IDirectoryInterface<ExternalDefinition, RequiredDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name);
                await json.Read(cancellationToken).ConfigureAwait(false);

                return json;
            }
            catch
            {
                return default;
            }
        }
    }

    extension(IDirectoryInterface<StrictDefinition, OptionalDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name);
                await json.Read(cancellationToken).ConfigureAwait(false);

                return json;
            }
            catch
            {
                return default;
            }
        }
    }

    extension(IDirectoryInterface<ExternalDefinition, OptionalDefinition> @interface)
    {
        public async ValueTask<IJsonResource<TData>?> GetJsonResource<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonDefinition.Convert<TData>(new FileContext(@interface.StorageBackend, @interface.Address), name);
                await json.Read(cancellationToken).ConfigureAwait(false);

                return json;
            }
            catch
            {
                return default;
            }
        }
    }
}
