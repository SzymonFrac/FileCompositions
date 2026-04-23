using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Collections.Immutable;

namespace FileCompositions.Core.File.LocationResolver.Implementations;

internal class FileLocationResolver(ImmutableDictionary<StorageResourceExtension, Func<IDirectoryLocation, StorageResourceName, IFileResource>> map) : IFileLocationResolver
{
    private readonly ImmutableDictionary<StorageResourceExtension, Func<IDirectoryLocation, StorageResourceName, IFileResource>> _map = map;
    public IFileResource? Resolve(IDirectoryLocation directory, StorageResourceName file) =>
        _map[file.Extension](directory, file);

    public TFile? Resolve<TFile>(IDirectoryLocation directory, StorageResourceName file) where TFile : IFileResource =>
        (TFile)_map[file.Extension](directory, file);

    public IEnumerable<IFileResource> ResolveRange(IDirectoryLocation directory, IEnumerable<StorageResourceName> files) =>
        files.Select(f => _map[f.Extension](directory, f));
}
