using FileCompositions.Core.Quality.Placement.Implementations;
using System.Reflection;
using System.Runtime.Loader;

namespace FileCompositions.Core.File.Interface.Specialized.Dll;

internal static class DllInterface
{
    private static IEnumerable<Type> GetTypesImplementing<TInterface>(Assembly assembly) =>
        assembly.GetTypes()
            .Where(t => typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface);

    // Add writing a dll if I can be bothered.

    extension(IDllInterface<RequiredInRequired> dll)
    {
        public async Task<Assembly> Load(CancellationToken cancellationToken = default) =>
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

        public async Task Run<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                await run(instance);
            }
        }
        public async Task Run<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                run?.Invoke(instance);
            }
        }
    }

    extension(IDllInterface<OptionalInRequired> dll)
    {
        public async Task<Assembly?> Load(CancellationToken cancellationToken = default)
        {
            var stream = await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            if (stream is null)
                return default;

            return dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(stream);
        }

        public async Task<bool> Run<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= await dll.Load(cancellationToken);
            if (dll.Assembly is null)
                return false;

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                await run(instance);
            }
            return true;
        }
        public async Task<bool> Run<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= await dll.Load(cancellationToken);
            if (dll.Assembly is null)
                return false;

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                run?.Invoke(instance);
            }
            return true;
        }
    }

    extension(IDllInterface<OptionalInOptional> dll)
    {
        public async Task<Assembly?> Load(CancellationToken cancellationToken = default)
        {
            var stream = await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            if (stream is null)
                return default;

            return dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(stream);
        }

        public async Task<bool> Run<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= await dll.Load(cancellationToken);
            if (dll.Assembly is null)
                return false;

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                await run(instance);
            }
            return true;
        }
        public async Task<bool> Run<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= await dll.Load(cancellationToken);
            if (dll.Assembly is null)
                return false;

            foreach (var type in GetTypesImplementing<TInterface>(dll.Assembly))
            {
                var instance = (TInterface)Activator.CreateInstance(type)!;
                run?.Invoke(instance);
            }
            return true;
        }
    }
}
