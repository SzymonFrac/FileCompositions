using FileCompositions.Core.FileResource.Specialized;

namespace FileCompositions.Core.Validation.Specialized.Implementations.Ensure;

public class EnsureResource : ISpecializedResourceValidation
{
    public static async Task<bool> Validate(ISpecializedFileResource fileResource) =>
        await fileResource.Context.StorageConnector.Exists(fileResource.Name);
}
