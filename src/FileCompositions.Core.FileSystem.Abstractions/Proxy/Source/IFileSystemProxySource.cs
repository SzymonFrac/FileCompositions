using FileCompositions.Core.FileSystem.Abstractions.Proxy.Request;

namespace FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;

public interface IFileSystemProxySource<TEntry>
    where TEntry : Entry
{
    Task RequestAsync(FileSystemProxyRequest<TEntry> request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemProxyRequest<TEntry, TResult> request, CancellationToken cancellationToken = default);
}
