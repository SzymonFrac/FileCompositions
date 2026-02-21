namespace FileCompositions.Core.FileResource.Implementations;

internal class FileResource(string name) : IFileResource
{
    public string Name { get; } = name;
}
