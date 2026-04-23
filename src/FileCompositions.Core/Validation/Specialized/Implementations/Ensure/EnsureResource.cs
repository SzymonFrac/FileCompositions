using FileCompositions.Core.File.Resource;

namespace FileCompositions.Core.Validation.Specialized.Implementations.Ensure;

public class EnsureResource : ISpecializedResourceValidation
{
    public static async Task<bool> Validate(IFileResource fileResource) =>
        await fileResource.Context.StorageConnector.Exists(fileResource.Name);
}
