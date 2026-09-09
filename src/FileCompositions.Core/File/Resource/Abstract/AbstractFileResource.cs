using FileCompositions.Core.File.Context;
using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.File.Source;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, Filename name) : IFileResource
{
    private readonly IFileContext _context = context;
    private readonly Filename _name = name;

    public FileAddressing Addressing => field ??= new(_context.DirectoryAddressing, _name);
    public IFileProxySource ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);
}
