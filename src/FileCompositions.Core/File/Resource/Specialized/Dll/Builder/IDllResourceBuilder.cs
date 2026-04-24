using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource.Builder;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder;

internal interface IDllResourceBuilder : IFileResourceBuilder
{
    new IDllResourceBuilder WithName(string name);

    internal IDllResource Build(IDirectoryLocation directory);
}
