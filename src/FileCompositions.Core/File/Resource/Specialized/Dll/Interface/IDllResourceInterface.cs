using FileCompositions.Core.File.Resource.Interface;
using System.Reflection;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Interface;

public interface IDllResourceInterface : IFileResourceInterface
{
    Task<Assembly> Load(CancellationToken cancellationToken = default);

    Task Run<TInterface>(Func<TInterface, Task> run, CancellationToken cancellationToken = default);
    Task Run<TInterface>(Action<TInterface>? run = default, CancellationToken cancellationToken = default);
}