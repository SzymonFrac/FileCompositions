using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder;

public interface IDllResourceBuilder : IFileResourceBuilder
{
    IDllResourceBuilder WithName(string name);

    internal IDllResource Build(in IFileContext context);
};
