using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Quality.Ext;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Extensions;

public static class DirectoryInterfaceResolveJson
{
    extension(IDirectoryInterface<StrictDefinition, RequiredDefinition> @interface)
    {
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(@interface.StorageBackend, @interface.GetAddress());
                var json = JsonDefinition.Convert<TData>(context, name);
                await json.ReadAsync(cancellationToken).ConfigureAwait(false);

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
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(@interface.StorageBackend, @interface.GetAddress());
                var json = JsonDefinition.Convert<TData>(context, name);
                await json.ReadAsync(cancellationToken).ConfigureAwait(false);

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
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(@interface.StorageBackend, @interface.GetAddress());
                var json = JsonDefinition.Convert<TData>(context, name);
                await json.ReadAsync(cancellationToken).ConfigureAwait(false);

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
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(@interface.StorageBackend, @interface.GetAddress());
                var json = JsonDefinition.Convert<TData>(context, name);
                await json.ReadAsync(cancellationToken).ConfigureAwait(false);

                return json;
            }
            catch
            {
                return default;
            }
        }
    }
}
