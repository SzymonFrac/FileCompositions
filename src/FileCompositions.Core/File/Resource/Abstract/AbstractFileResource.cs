using FileCompositions.Core.File.Context;
using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Name;
using FileCompositions.Core.FileSystem.Proxy.File.Source;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, FileSystemFilename name) : IFileResource
{
    private readonly IFileContext _context = context;
    private readonly FileSystemFilename _name = name;

    public FileSystemFileAddressing Addressing => field ??= new(_context.DirectoryAddressing, _name);
    public IFileSystemFileProxySource ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);
}
