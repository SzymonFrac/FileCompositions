namespace FileCompositions.Core.FileSystem.Request;

internal static partial class FileSystemRequest
{
    public delegate Task Location(IFileSystem.LocationSession locationSession, CancellationToken cancellationToken = default);
    public delegate Task<TResult> Location<TResult>(IFileSystem.LocationSession locationSession, CancellationToken cancellationToken = default);
}
