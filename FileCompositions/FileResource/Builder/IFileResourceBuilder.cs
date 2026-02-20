namespace FileCompositions.Core.FileResource.Builder;

public interface IFileResourceBuilder
{
    IFileResourceBuilder WithName(string name);
    internal IFileResource Build();
}
