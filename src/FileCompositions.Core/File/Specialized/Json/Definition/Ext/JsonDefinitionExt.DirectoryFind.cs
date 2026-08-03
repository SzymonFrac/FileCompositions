using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Quality.Ext;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(directory.Context.FileSystem, directory.Address);
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

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(directory.Context.FileSystem, directory.Address);
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

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(directory.Context.FileSystem, directory.Address);
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

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        public async Task<IJsonResource<TData>?> GetJsonResourceAsync<TData>(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var context = new FileContext(directory.Context.FileSystem, directory.Address);
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
