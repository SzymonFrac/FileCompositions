namespace FileCompositions.Core.FileSystem.Abstractions.Proxy.Request;

public delegate Task FileSystemProxyRequest<TEntry>(IFileSystemProxy<TEntry> proxy, CancellationToken cancellationToken = default)
    where TEntry : Entry;
public delegate Task<TResult> FileSystemProxyRequest<TEntry, TResult>(IFileSystemProxy<TEntry> session, CancellationToken cancellationToken = default)
    where TEntry : Entry;
