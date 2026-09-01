namespace FileCompositions.Core.FileSystem.Request;

internal static partial class FileSystemRequest
{
    public delegate Task Address(IFileSystem.AddressSession addressSession, CancellationToken cancellationToken = default);
    public delegate Task<TResult> Address<TResult>(IFileSystem.AddressSession addressSession, CancellationToken cancellationToken = default);
}
