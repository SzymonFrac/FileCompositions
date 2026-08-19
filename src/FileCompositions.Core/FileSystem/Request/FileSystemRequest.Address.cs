namespace FileCompositions.Core.FileSystem.Request;

internal static partial class FileSystemRequest
{
    public delegate ValueTask Address(IFileSystem.AddressSession addressSession, CancellationToken cancellationToken = default);
    public delegate ValueTask<TResult> Address<TResult>(IFileSystem.AddressSession addressSession, CancellationToken cancellationToken = default);
}
