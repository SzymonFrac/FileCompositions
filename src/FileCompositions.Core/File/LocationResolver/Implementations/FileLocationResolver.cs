using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Collections.Immutable;

namespace FileCompositions.Core.File.LocationResolver.Implementations;

internal class FileLocationResolver(ImmutableDictionary<StorageResourceExtension, Func<IDirectoryLocation, StorageResourceName, ISpecializedFileResource>> map) : IFileLocationResolver
{
    private readonly ImmutableDictionary<StorageResourceExtension, Func<IDirectoryLocation, StorageResourceName, ISpecializedFileResource>> _map = map;
    public ISpecializedFileResource? Resolve(IDirectoryLocation directory, StorageResourceName file) =>
        _map[file.Extension](directory, file);

    public TFile? Resolve<TFile>(IDirectoryLocation directory, StorageResourceName file) where TFile : ISpecializedFileResource =>
        (TFile)_map[file.Extension](directory, file);

    public IEnumerable<ISpecializedFileResource> ResolveRange(IDirectoryLocation directory, IEnumerable<StorageResourceName> files) =>
        files.Select(f => _map[f.Extension](directory, f));
}
