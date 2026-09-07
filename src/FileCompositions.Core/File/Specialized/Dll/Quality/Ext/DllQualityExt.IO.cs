using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace FileCompositions.Core.File.Specialized.Dll.Quality.Ext;

public static partial class DllQualityExt
{
    private static IEnumerable<TInterface> CreateInstances<TInterface>(Assembly assembly) =>
        assembly.GetTypes()
            .Where(t => typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(type => (TInterface)Activator.CreateInstance(type)!);

    extension(IDllQuality<Ownership.Internal, Placement.RequiredInRequired> dll)
    {
        public async Task<Assembly> LoadAsync(CancellationToken cancellationToken = default) =>
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));


        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance, cancellationToken);
        }
        public async Task RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance);
        }

        public async Task RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);
        }
    }

    extension(IDllQuality<Ownership.External, Placement.RequiredInRequired> dll)
    {
        public async Task<Assembly> LoadAsync(CancellationToken cancellationToken = default) =>
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));


        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance, cancellationToken);
        }
        public async Task RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance);
        }

        public async Task RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            dll.Assembly ??= AssemblyLoadContext.Default.LoadFromStream(
                await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false));

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);
        }
    }

    extension(IDllQuality<Ownership.Internal, Placement.OptionalInRequired> dll)
    {
        public async Task<Assembly?> LoadAsync(CancellationToken cancellationToken = default) =>
            await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is Stream stream
                ? dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream)
                : default;


        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var task in Task.WhenEach(tasks))
                yield return await task.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task<bool> RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await Task.WhenAll(tasks);

            return true;
        }
        public async Task<bool> RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await Task.WhenAll(tasks);

            return true;
        }

        public async Task<bool> RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);

            return true;
        }
    }

    extension(IDllQuality<Ownership.External, Placement.OptionalInRequired> dll)
    {
        public async Task<Assembly?> LoadAsync(CancellationToken cancellationToken = default) =>
            await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is Stream stream
                ? dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream)
                : default;


        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task<bool> RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance, cancellationToken);

            return true;
        }
        public async Task<bool> RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance);

            return true;
        }

        public async Task<bool> RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);

            return true;
        }
    }

    extension(IDllQuality<Ownership.Internal, Placement.OptionalInOptional> dll)
    {
        public async Task<Assembly?> LoadAsync(CancellationToken cancellationToken = default) =>
            await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is Stream stream
                ? dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream)
                : default;


        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task<bool> RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance, cancellationToken);

            return true;
        }
        public async Task<bool> RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance);

            return true;
        }

        public async Task<bool> RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);

            return true;
        }
    }

    extension(IDllQuality<Ownership.External, Placement.OptionalInOptional> dll)
    {
        public async Task<Assembly?> LoadAsync(CancellationToken cancellationToken = default) =>
            await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is Stream stream
                ? dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream)
                : default;

        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }
        public async IAsyncEnumerable<TResult> RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                yield break;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            await foreach (var item in Task.WhenEach(tasks))
                yield return await item.ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i, cancellationToken));

            return await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TResult>> RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return [];

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            var tasks = CreateInstances<TInterface>(dll.Assembly)
                .Select(i => run(i));

            return await Task.WhenAll(tasks);
        }

        public async Task<bool> RunAsync<TInterface>(Func<TInterface, CancellationToken, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance, cancellationToken);

            return true;
        }
        public async Task<bool> RunAsync<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                await run(instance);

            return true;
        }

        public async Task<bool> RunAsync<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default)
        {
            if (await dll.OpenReadAsync(cancellationToken).ConfigureAwait(false) is not Stream stream)
                return false;

            dll.Assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

            foreach (var instance in CreateInstances<TInterface>(dll.Assembly))
                run?.Invoke(instance);

            return true;
        }
    }
}
