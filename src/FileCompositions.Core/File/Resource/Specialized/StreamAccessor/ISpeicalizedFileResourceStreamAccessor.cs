namespace FileCompositions.Core.File.Resource.Specialized.StreamAccessor;

public interface ISpeicalizedFileResourceStreamAccessor
{
    internal Task<Stream> OpenReadAsync();
    internal Task<Stream> OpenWriteAsync();
}
