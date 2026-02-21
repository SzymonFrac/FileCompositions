namespace FileCompositions.Core.FileResource.Builder.Implementations;

internal class FileResourceBuilder : IFileResourceBuilder
{
    private string? name;
    //private object? validation;
    public IFileResourceBuilder WithName(string n)
    {
        name = n;
        return this;
    }

    public IFileResource Build()
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        return new FileResource.Implementations.FileResource(name);
    }
}
