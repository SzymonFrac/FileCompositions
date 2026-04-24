using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Dll.Context;
using FileCompositions.Core.Storage.ResourceName;
using System.Reflection;
using System.Runtime.Loader;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Implementations;

internal class DllResource(IDllResourceContext context, StorageResourceName name)
    : AbstractFileResource(context, name), IDllResource
{
    new public IDllResourceContext Context { get; } = context;
    private Assembly? cache;

    public async Task<Assembly> Load(CancellationToken cancellationToken = default) =>
        cache ??= AssemblyLoadContext.Default.LoadFromStream(
            await OpenReadAsync(cancellationToken).ConfigureAwait(false));

    public async Task Run<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
    {
        cache ??= await Load(cancellationToken).ConfigureAwait(false);

        foreach (var type in GetTypesImplementing<TInterface>(cache))
        {
            var instance = (TInterface)Activator.CreateInstance(type)!;
            await run(instance);
        }
    }
    public async Task Run<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
    {
        cache ??= await Load(cancellationToken).ConfigureAwait(false);

        foreach (var type in GetTypesImplementing<TInterface>(cache))
        {
            var instance = (TInterface)Activator.CreateInstance(type)!;
            run?.Invoke(instance);
        }
    }

    private static IEnumerable<Type> GetTypesImplementing<TInterface>(Assembly assembly) =>
        assembly.GetTypes()
            .Where(t => typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface);
}
