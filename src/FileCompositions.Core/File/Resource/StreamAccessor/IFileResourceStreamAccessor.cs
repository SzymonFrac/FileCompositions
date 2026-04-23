namespace FileCompositions.Core.File.Resource.StreamAccessor;

public interface IFileResourceStreamAccessor
{
    internal Task<Stream> OpenReadAsync();
    internal Task<Stream> OpenWriteAsync();
}
