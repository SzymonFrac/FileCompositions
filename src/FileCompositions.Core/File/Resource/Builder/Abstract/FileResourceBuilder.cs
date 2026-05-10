namespace FileCompositions.Core.File.Resource.Builder.Abstract;

// Might not be able to build a resource
// But only query them
// Unless I allow DirectoryLocation to add a resource
// (but isn't defined)
internal abstract class FileResourceBuilder
{
    protected string? Name { get; set; }
}
