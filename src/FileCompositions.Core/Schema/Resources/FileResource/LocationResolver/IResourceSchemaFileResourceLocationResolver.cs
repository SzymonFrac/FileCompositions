using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.Schema.Resources.FileResource.LocationResolver;

internal interface IResourceSchemaFileResourceLocationResolver
{
    ISpecializedFileResource? Resolve(in StorageLocation location);
    TFile? Resolve<TFile>(in StorageLocation location)
        where TFile : ISpecializedFileResource;
    IEnumerable<ISpecializedFileResource> ResolveRange(in StorageLocation location);
}
