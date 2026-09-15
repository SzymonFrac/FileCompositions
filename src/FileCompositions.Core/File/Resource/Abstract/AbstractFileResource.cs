using FileCompositions.Core.File.Context;
using FileCompositions.Core.FileSystem.Abstractions;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, Filename name) : IFileResource
{
    private readonly IFileContext _context = context;
    private readonly Filename _name = name;

    public Location Location => field ??= _context.Address.With(_name);
    public IFileSystemProxySource<Entry.File> ProxySource => field ??= _context.SessionSource.RequestProxySource(Location);
}
