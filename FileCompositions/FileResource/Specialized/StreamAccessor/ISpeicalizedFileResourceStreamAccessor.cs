namespace FileCompositions.Core.FileResource.Specialized.StreamAccessor;

public interface ISpeicalizedFileResourceStreamAccessor
{
    internal Task<Stream> OpenReadAsync();
    internal Task<Stream> OpenWriteAsync();
}
