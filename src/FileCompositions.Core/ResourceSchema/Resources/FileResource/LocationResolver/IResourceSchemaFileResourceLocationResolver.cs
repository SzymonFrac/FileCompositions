using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.ResourceSchema.Resources.FileResource.LocationResolver;

internal interface IResourceSchemaFileResourceLocationResolver
{
    IFileResource? Resolve(in StorageLocation location);
    TFile? Resolve<TFile>(in StorageLocation location)
        where TFile : IFileResource;
    IEnumerable<IFileResource> ResolveRange(in StorageLocation location);
}
